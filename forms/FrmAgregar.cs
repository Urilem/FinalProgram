using System;
using System.Windows.Forms;

namespace FinalProgram
{
    public partial class FrmAgregar : Form
    {
        public FrmAgregar()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar y crear producto
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("Precio inválido");
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int stock))
                {
                    MessageBox.Show("Cantidad inválida");
                    return;
                }

                var producto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = precio,
                    Stock = stock
                };

                // Usar el servicio global
                Program.ProductoService.AgregarProducto(producto);

                MessageBox.Show("Producto agregado correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
