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
            // Datos de ejemplo REALISTAS para casa de comida
            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            // Comidas típicas de casa de comida con precios realistas
            Agregar(new Producto { 
                Nombre = "Empanada Carne Casera", 
                Categoria = "Entrada",
                Descripcion = "Empanadas horneadas con carne picada, cebolla y especias",
                Precio = 180.50m,  // Precio por unidad
                Stock = 100
            });
            
            Agregar(new Producto { 
                Nombre = "Milanesa con Papas", 
                Categoria = "Principal",
                Descripcion = "Milanesa de ternera con papas fritas caseras",
                Precio = 1250.00m, 
                Stock = 50
            });
            
            Agregar(new Producto { 
                Nombre = "Pizza Mozzarella", 
                Categoria = "Principal",
                Descripcion = "Pizza con salsa de tomate y queso mozzarella",
                Precio = 980.00m, 
                Stock = 30
            });
            
            Agregar(new Producto { 
                Nombre = "Ensalada César", 
                Categoria = "Entrada",
                Descripcion = "Lechuga, crutones, queso parmesano y aderezo césar",
                Precio = 720.00m, 
                Stock = 25
            });
            
            Agregar(new Producto { 
                Nombre = "Flan Casero", 
                Categoria = "Postre",
                Descripcion = "Flan de huevo con dulce de leche y crema",
                Precio = 450.75m, 
                Stock = 40
            });
            
            Agregar(new Producto { 
                Nombre = "Limonada Natural", 
                Categoria = "Bebida",
                Descripcion = "Limonada fresca con hielo y menta",
                Precio = 320.00m, 
                Stock = 80
            });
            
            Agregar(new Producto { 
                Nombre = "Café Americano", 
                Categoria = "Bebida",
                Descripcion = "Café negro recién preparado",
                Precio = 180.00m, 
                Stock = 60
            });
            
            Agregar(new Producto { 
                Nombre = "Medialuna", 
                Categoria = "Desayuno/Merienda",
                Descripcion = "Medialuna de manteca",
                Precio = 120.00m, 
                Stock = 75
            });
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
                existente.Categoria = producto.Categoria;
                existente.Descripcion = producto.Descripcion;
                existente.Precio = producto.Precio;
                existente.Stock = producto.Stock;
                existente.Disponible = producto.Disponible;
            }
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
                _productos.Remove(producto);
        }

        // Método adicional para resetear datos de prueba
        public void ResetearDatosDePrueba()
        {
            _productos.Clear();
            _nextId = 1;
            CargarDatosDePrueba();
        }
    }
}
