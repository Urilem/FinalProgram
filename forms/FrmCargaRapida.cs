using System;
using System.Windows.Forms;

namespace FinalProgram
{
    public partial class FrmCargaRapida : Form
    {
        public FrmCargaRapida()
        {
            InitializeComponent();
        }

        private void btnCargarEjemplos_Click(object sender, EventArgs e)
        {
            try
            {
                var service = Program.ProductoService;
                
                // Limpiar productos existentes
                var productos = service.ObtenerTodos();
                foreach (var p in productos)
                {
                    service.EliminarProducto(p.Id);
                }
                
                // Cargar nuevos productos de ejemplo
                var productosEjemplo = new[]
                {
                    new { Nombre = "Empanada Jamón y Queso", Precio = 150m, Stock = 50 },
                    new { Nombre = "Milanesa Napolitana", Precio = 1350m, Stock = 30 },
                    new { Nombre = "Fideos con Tuco", Precio = 850m, Stock = 40 },
                    new { Nombre = "Ensalada Mixta", Precio = 650m, Stock = 25 },
                    new { Nombre = "Flan con Dulce", Precio = 480m, Stock = 35 },
                    new { Nombre = "Coca-Cola 500ml", Precio = 280m, Stock = 60 },
                    new { Nombre = "Café Cortado", Precio = 180m, Stock = 100 }
                };

                foreach (var p in productosEjemplo)
                {
                    service.AgregarProducto(new Producto { Nombre = p.Nombre, Precio = p.Precio, Stock = p.Stock });
                }

                MessageBox.Show("✅ 7 productos de ejemplo cargados!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
