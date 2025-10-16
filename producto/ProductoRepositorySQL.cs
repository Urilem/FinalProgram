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
                    Categoria NVARCHAR(50),
                    Descripcion NVARCHAR(255),
                    Precio DECIMAL(18,2) NOT NULL,
                    Stock INT NOT NULL,
                    Disponible BIT DEFAULT 1,
                    TiempoPreparacion TIME
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
            var sql = @"INSERT INTO Productos (Nombre, Categoria, Descripcion, Precio, Stock, Disponible, TiempoPreparacion)
                       VALUES (@Nombre, @Categoria, @Descripcion, @Precio, @Stock, @Disponible, @TiempoPreparacion);
                       SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
                command.Parameters.AddWithValue("@Descripcion", (object)producto.Descripcion ?? DBNull.Value);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@Disponible", producto.Disponible);
                command.Parameters.AddWithValue("@TiempoPreparacion", (object)producto.TiempoPreparacion ?? DBNull.Value);

                connection.Open();
                producto.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Actualizar(Producto producto)
        {
            var sql = @"UPDATE Productos 
                       SET Nombre = @Nombre, Categoria = @Categoria, Descripcion = @Descripcion,
                           Precio = @Precio, Stock = @Stock, Disponible = @Disponible,
                           TiempoPreparacion = @TiempoPreparacion
                       WHERE Id = @Id";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", producto.Id);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
                command.Parameters.AddWithValue("@Descripcion", (object)producto.Descripcion ?? DBNull.Value);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@Disponible", producto.Disponible);
                command.Parameters.AddWithValue("@TiempoPreparacion", (object)producto.TiempoPreparacion ?? DBNull.Value);

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
                Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? null : reader.GetString(reader.GetOrdinal("Categoria")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                Disponible = reader.GetBoolean(reader.GetOrdinal("Disponible")),
                TiempoPreparacion = reader.IsDBNull(reader.GetOrdinal("TiempoPreparacion")) ? TimeSpan.Zero : reader.GetTimeSpan(reader.GetOrdinal("TiempoPreparacion"))
            };
        }
    }
}
