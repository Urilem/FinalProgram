using System;
using System.Collections.Generic;
using System.Linq;
using FinalProgram.Modelos;
using FinalProgram.AccesoDatos;

namespace FinalProgram.Servicios
{
  public class ServicioVentas
  {
    private readonly IRepositorioProductos _repositorioProductos;

    public ServicioVentas(IRepositorioProductos repositorioProductos)
    {
      _repositorioProductos = repositorioProductos;
    }

    public Venta ProcesarVenta(List<DetalleVenta> detallesVenta)
    {
      var venta = new Venta();

      foreach (var detalle in detallesVenta)
      {
        // Validar stock
        var producto = _repositorioProductos.ObtenerPorId(detalle.Producto.Id);
        if (producto == null)
          throw new ArgumentException($"Producto no encontrado: {detalle.Producto.Nombre}");

        if (producto.Stock < detalle.Cantidad)
          throw new ArgumentException($"Stock insuficiente para {producto.Nombre}. Disponible: {producto.Stock}");

        // Actualizar stock
        _repositorioProductos.ActualizarStock(producto.Id, producto.Stock - detalle.Cantidad);

        // Agregar a la venta
        venta.Detalles.Add(detalle);
      }

      venta.CalcularTotal();
      return venta;
    }

    public decimal CalcularTotalVenta(List<DetalleVenta> detalles)
    {
      return detalles.Sum(d => d.Subtotal);
    }
  }
}
