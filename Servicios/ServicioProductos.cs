using System;
using System.Collections.Generic;
using FinalProgram.Modelos;
using FinalProgram.AccesoDatos;

namespace FinalProgram.Servicios
{
  public class ServicioProductos
  {
    private readonly IRepositorioProductos _repositorio;

    public ServicioProductos(IRepositorioProductos repositorio)
    {
      _repositorio = repositorio;
    }

    public List<Producto> ObtenerTodosLosProductos() => _repositorio.ObtenerTodos();

    public Producto ObtenerProductoPorId(int id) => _repositorio.ObtenerPorId(id);

    public void AgregarProducto(Producto producto)
    {
      if (string.IsNullOrWhiteSpace(producto.Nombre))
        throw new ArgumentException("El nombre es obligatorio");

      if (producto.Precio <= 0)
        throw new ArgumentException("El precio debe ser mayor a 0");

      if (producto.Stock < 0)
        throw new ArgumentException("El stock no puede ser negativo");

      _repositorio.Agregar(producto);
    }

    // ✅ AÑADIR ESTE MÉTODO QUE FALTA
    public void ActualizarProducto(Producto producto)
    {
      if (string.IsNullOrWhiteSpace(producto.Nombre))
        throw new ArgumentException("El nombre es obligatorio");

      if (producto.Precio <= 0)
        throw new ArgumentException("El precio debe ser mayor a 0");

      if (producto.Stock < 0)
        throw new ArgumentException("El stock no puede ser negativo");

      _repositorio.Actualizar(producto);
    }

    public void VenderProducto(int id, int cantidad)
    {
      var producto = _repositorio.ObtenerPorId(id);
      if (producto == null)
        throw new ArgumentException("Producto no encontrado");

      if (producto.Stock < cantidad)
        throw new ArgumentException($"Stock insuficiente. Disponible: {producto.Stock}");

      producto.Stock -= cantidad;
      _repositorio.Actualizar(producto);
    }
  }
}
