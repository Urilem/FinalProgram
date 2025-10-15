using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProgram
{
    public partial class FrmTicket : Form
    {
        private decimal _totalVenta;
        private System.Collections.Generic.List<DetalleVenta> _detalles;

        public FrmTicket(System.Collections.Generic.List<DetalleVenta> detalles, decimal totalVenta)
        {
            InitializeComponent();
            _detalles = detalles;
            _totalVenta = totalVenta;
            MostrarTicket();
        }

        private void MostrarTicket()
        {
            var sb = new StringBuilder();
            
            // Encabezado del ticket
            sb.AppendLine("🍕 CASA DE COMIDA CASERA");
            sb.AppendLine("================================");
            sb.AppendLine($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
            sb.AppendLine("================================");
            sb.AppendLine();

            // Detalles de productos
            foreach (var detalle in _detalles)
            {
                sb.AppendLine($"{detalle.Producto.Nombre}");
                sb.AppendLine($"  {detalle.Cantidad} x {detalle.PrecioUnitario:C2} = {detalle.Subtotal:C2}");
            }

            sb.AppendLine();
            sb.AppendLine("================================");
            sb.AppendLine($"TOTAL: {_totalVenta:C2}");
            sb.AppendLine("================================");
            sb.AppendLine("¡Gracias por su compra!");
            sb.AppendLine("Vuelva pronto! 🍕");

            txtTicket.Text = sb.ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Aquí puedes implementar impresión real
            MessageBox.Show("¡Ticket listo para imprimir!", "Imprimir", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
