using System;

namespace FinalProgram.Modelos
{
  public class DetalleVenta
  {
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;

    // Propiedades para mostrar en tablas
    public string NombreProducto => Producto?.Nombre ?? "N/A";
    public string PrecioUnitarioFormateado => PrecioUnitario.ToString("C2");
    public string SubtotalFormateado => Subtotal.ToString("C2");
  }
}
