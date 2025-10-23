using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalProgram
{
  public class ProductoRepositorySQL : IProductoRepository
  {
    private readonly string _connectionString;

    public ProductoRepositorySQL()
    {
      _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
      EnsureTableExists();
    }

    private void EnsureTableExists()
    {
      var createTableSql = @"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Productos' AND xtype='U')
        CREATE TABLE Productos (
          Id INT IDENTITY(1,1) PRIMARY KEY,
          Nombre NVARCHAR(100) NOT NULL,
          Precio DECIMAL(18,2) NOT NULL,
          Stock INT NOT NULL,
        )";
    
      using (var connection = new SqlConnection(_connectionString))
      using (var command = new SqlCommand(createTableSql, connection))
      {
        connection.Open();
        command.ExecuteNonQuery();
      }
    }

    public void Agregar(Producto producto)
    {
      var sql = @"INSERT INTO Productos (Nombre, Precio, Stock)
                VALUES (@Nombre, @Precio, @Stock);
                SELECT SCOPE_IDENTITY();";

      using (var connection = new SqlConnection(_connectionString))
      using (var command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
        command.Parameters.AddWithValue("@Precio", producto.Precio);
        command.Parameters.AddWithValue("@Stock", producto.Stock);

        connection.Open();
        producto.Id = Convert.ToInt32(command.ExecuteScalar());
      }
    }

    public void Actualizar(Producto producto)
    {
    var sql = @"UPDATE Productos 
              SET Nombre = @Nombre,
                  Precio = @Precio,
                  Stock = @Stock
              WHERE Id = @Id";

      using (var connection = new SqlConnection(_connectionString))
      using (var command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Id", producto.Id);
        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
        command.Parameters.AddWithValue("@Precio", producto.Precio);
        command.Parameters.AddWithValue("@Stock", producto.Stock);

        connection.Open();
        command.ExecuteNonQuery();
      }
    }

    public void Eliminar(int id)
    {
      var sql = "DELETE FROM Productos WHERE Id = @Id";

      using (var connection = new SqlConnection(_connectionString))
      using (var command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();
        command.ExecuteNonQuery();
      }
    }

    public Producto ObtenerPorId(int id)
    {
      var sql = "SELECT * FROM Productos WHERE Id = @Id";

      using (var connection = new SqlConnection(_connectionString))
      using (var command = new SqlCommand(sql, connection))
      {
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();

        using (var reader = command.ExecuteReader())
        {
          if (reader.Read())
          {
              return MapReaderToProducto(reader);
          }
        }
      }
      return null;
    }

    public List<Producto> ObtenerTodos()
    {
      var productos = new List<Producto>();
      var sql = "SELECT * FROM Productos ORDER BY Nombre";

      using (var connection = new SqlConnection(_connectionString))
      using (var command = new SqlCommand(sql, connection))
      {
        connection.Open();

        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
              productos.Add(MapReaderToProducto(reader));
          }
        }
      }
      return productos;
    }

    private Producto MapReaderToProducto(SqlDataReader reader)
    {
      return new Producto
      {
        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
        Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),
        Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
      };
    }
  }
}
