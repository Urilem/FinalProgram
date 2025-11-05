using System;
using System.Collections.Generic;

namespace FinalProgram.Modelos
{
  public class Venta
  {
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public List<DetalleVenta> Detalles { get; set; }
    public decimal Total { get; set; }

    public Venta()
    {
      Detalles = new List<DetalleVenta>();
      Fecha = DateTime.Now;
    }

    public void CalcularTotal()
    {
      Total = 0;
      foreach (var detalle in Detalles)
      {
        Total += detalle.Subtotal;
      }
    }
  }
}
