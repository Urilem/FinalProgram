using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FinalProgram
{
    public class ProductoRepositoryJson : IProductoRepository
    {
        private List<Producto> _productos;
        private readonly string _archivoDatos = "productos.json";
        private int _nextId = 1;

        public ProductoRepositoryJson()
        {
            _productos = CargarProductos();
            _nextId = _productos.Count > 0 ? _productos.Max(p => p.Id) + 1 : 1;
        }

        private List<Producto> CargarProductos()
        {
            try
            {
                if (File.Exists(_archivoDatos))
                {
                    var json = File.ReadAllText(_archivoDatos);
                    return JsonConvert.DeserializeObject<List<Producto>>(json) ?? new List<Producto>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando productos: {ex.Message}");
            }

            // Si no existe el archivo o hay error, cargar datos de prueba
            return CargarDatosDePrueba();
        }

        private List<Producto> CargarDatosDePrueba()
        {
            return new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Empanada Carne Casera", Categoria = "Entrada", Precio = 180.50m, Stock = 100 },
                new Producto { Id = 2, Nombre = "Milanesa con Papas", Categoria = "Principal", Precio = 1250.00m, Stock = 50 },
                new Producto { Id = 3, Nombre = "Pizza Mozzarella", Categoria = "Principal", Precio = 980.00m, Stock = 30 },
                new Producto { Id = 4, Nombre = "Limonada Natural", Categoria = "Bebida", Precio = 320.00m, Stock = 80 }
            };
        }

        private void GuardarProductos()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_productos, Formatting.Indented);
                File.WriteAllText(_archivoDatos, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error guardando productos: {ex.Message}");
            }
        }

        public List<Producto> ObtenerTodos() => _productos;

        public Producto ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

        public void Agregar(Producto producto)
        {
            producto.Id = _nextId++;
            _productos.Add(producto);
            GuardarProductos();
        }

        public void Actualizar(Producto producto)
        {
            var existente = ObtenerPorId(producto.Id);
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Categoria = producto.Categoria;
                existente.Descripcion = producto.Descripcion;
                existente.Precio = producto.Precio;
                existente.Stock = producto.Stock;
                existente.Disponible = producto.Disponible;
                GuardarProductos();
            }
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                _productos.Remove(producto);
                GuardarProductos();
            }
        }
    }
}
