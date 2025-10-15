// ProductoService.cs
using System;
using System.Collections.Generic;

namespace FinalProgram
{
    public class ProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        // Métodos que usarán los formularios
        public List<Producto> ObtenerTodos() => _repository.ObtenerTodos();
        public Producto ObtenerPorId(int id) => _repository.ObtenerPorId(id);
        
        public void AgregarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre es obligatorio");
                
            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");
                
            if (producto.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo");

            _repository.Agregar(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre es obligatorio");
                
            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");
                
            if (producto.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo");

            _repository.Actualizar(producto);
        }

        public void EliminarProducto(int id) => _repository.Eliminar(id);

        public void VenderProducto(int id, int cantidad)
        {
            var producto = _repository.ObtenerPorId(id);
            if (producto == null)
                throw new ArgumentException("Producto no encontrado");
                
            if (producto.Stock < cantidad)
                throw new ArgumentException($"Stock insuficiente. Disponible: {producto.Stock}");

            producto.Stock -= cantidad;
            _repository.Actualizar(producto);
        }
    }
}
