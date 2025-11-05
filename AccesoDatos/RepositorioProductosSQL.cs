using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using FinalProgram.Modelos;

namespace FinalProgram.AccesoDatos
{
  public class RepositorioProductosSQL : IRepositorioProductos
  {
    private readonly ConexionBD _conexionBD;

    public RepositorioProductosSQL()
    {
      try
      {
        _conexionBD = new ConexionBD();

        // Probar conexión al crear el repositorio
        _conexionBD.ProbarConexion();

        CrearTablaSiNoExiste();
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al inicializar el repositorio: {ex.Message}",
                      "Error de Inicialización",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    private void CrearTablaSiNoExiste()
    {
      var sql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Productos' AND xtype='U')
                CREATE TABLE Productos (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nombre NVARCHAR(100) NOT NULL,
                    Precio DECIMAL(18,2) NOT NULL,
                    Stock INT NOT NULL
                )";

      try
      {
        using (var conexion = _conexionBD.ObtenerConexion())
        using (var comando = new SqlCommand(sql, conexion))
        {
          conexion.Open();
          comando.ExecuteNonQuery();
          Console.WriteLine("✅ Tabla 'Productos' verificada/creada correctamente");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al crear la tabla: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    public void Agregar(Producto producto)
    {
      var sql = @"INSERT INTO Productos (Nombre, Precio, Stock)
                      VALUES (@Nombre, @Precio, @Stock);
                      SELECT SCOPE_IDENTITY();";

      try
      {
        using (var conexion = _conexionBD.ObtenerConexion())
        using (var comando = new SqlCommand(sql, conexion))
        {
          comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
          comando.Parameters.AddWithValue("@Precio", producto.Precio);
          comando.Parameters.AddWithValue("@Stock", producto.Stock);

          conexion.Open();
          producto.Id = Convert.ToInt32(comando.ExecuteScalar());
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al agregar producto: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    public void Actualizar(Producto producto)
    {
      var sql = @"UPDATE Productos 
                      SET Nombre = @Nombre,
                          Precio = @Precio,
                          Stock = @Stock
                      WHERE Id = @Id";

      try
      {
        using (var conexion = _conexionBD.ObtenerConexion())
        using (var comando = new SqlCommand(sql, conexion))
        {
          comando.Parameters.AddWithValue("@Id", producto.Id);
          comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
          comando.Parameters.AddWithValue("@Precio", producto.Precio);
          comando.Parameters.AddWithValue("@Stock", producto.Stock);

          conexion.Open();
          comando.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al actualizar producto: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    public void Eliminar(int id)
    {
      var sql = "DELETE FROM Productos WHERE Id = @Id";

      try
      {
        using (var conexion = _conexionBD.ObtenerConexion())
        using (var comando = new SqlCommand(sql, conexion))
        {
          comando.Parameters.AddWithValue("@Id", id);
          conexion.Open();
          comando.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al eliminar producto: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    public Producto ObtenerPorId(int id)
    {
      var sql = "SELECT * FROM Productos WHERE Id = @Id";

      try
      {
        using (var conexion = _conexionBD.ObtenerConexion())
        using (var comando = new SqlCommand(sql, conexion))
        {
          comando.Parameters.AddWithValue("@Id", id);
          conexion.Open();

          using (var lector = comando.ExecuteReader())
          {
            if (lector.Read())
            {
              return new Producto
              {
                Id = lector.GetInt32(lector.GetOrdinal("Id")),
                Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                Precio = lector.GetDecimal(lector.GetOrdinal("Precio")),
                Stock = lector.GetInt32(lector.GetOrdinal("Stock"))
              };
            }
          }
        }
        return null;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al obtener producto por ID: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    public List<Producto> ObtenerTodos()
    {
      var productos = new List<Producto>();
      var sql = "SELECT * FROM Productos ORDER BY Nombre";

      try
      {
        using (var conexion = _conexionBD.ObtenerConexion())
        using (var comando = new SqlCommand(sql, conexion))
        {
          conexion.Open();
          using (var lector = comando.ExecuteReader())
          {
            while (lector.Read())
            {
              productos.Add(new Producto
              {
                Id = lector.GetInt32(lector.GetOrdinal("Id")),
                Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                Precio = lector.GetDecimal(lector.GetOrdinal("Precio")),
                Stock = lector.GetInt32(lector.GetOrdinal("Stock"))
              });
            }
          }
        }
        return productos;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al obtener todos los productos: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    public void ActualizarStock(int id, int nuevoStock)
    {
      var sql = "UPDATE Productos SET Stock = @Stock WHERE Id = @Id";

      try
      {
        using (var conexion = _conexionBD.ObtenerConexion())
        using (var comando = new SqlCommand(sql, conexion))
        {
          comando.Parameters.AddWithValue("@Stock", nuevoStock);
          comando.Parameters.AddWithValue("@Id", id);

          conexion.Open();
          comando.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al actualizar stock: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }
  }
}
