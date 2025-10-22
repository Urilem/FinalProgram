using System;

namespace FinalProgram
{
  public class DetalleVenta
  {
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;
    
    // Propiedades para el DataGridView
    public string NombreProducto => Producto?.Nombre ?? "N/A";
    public string PrecioUnitarioFormateado => PrecioUnitario.ToString("C2");
    public string SubtotalFormateado => Subtotal.ToString("C2");
  }
}
