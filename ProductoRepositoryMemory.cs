// ProductoRepositoryMemory.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProgram
{
    public class ProductoRepositoryMemory : IProductoRepository
    {
        private List<Producto> _productos = new List<Producto>();
        private int _nextId = 1;

        public ProductoRepositoryMemory()
        {
            // Datos de ejemplo para pruebas
            Agregar(new Producto { Nombre = "Laptop", Precio = 1500.50m, Stock = 10 });
            Agregar(new Producto { Nombre = "Mouse", Precio = 25.99m, Stock = 50 });
            Agregar(new Producto { Nombre = "Teclado", Precio = 45.75m, Stock = 30 });
        }

        public List<Producto> ObtenerTodos() => _productos;

        public Producto ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

        public void Agregar(Producto producto)
        {
            producto.Id = _nextId++;
            _productos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            var existente = ObtenerPorId(producto.Id);
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Precio = producto.Precio;
                existente.Stock = producto.Stock;
            }
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
                _productos.Remove(producto);
        }
    }
}
