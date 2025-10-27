using System;
using System.Windows.Forms;

namespace FinalProgram
{
  public partial class FrmModificar : Form
  {
    public FrmModificar()
    {
      InitializeComponent();
      btnCancelar.Click += (s, e) => this.Close();
      btnConfirmar.Click += btnConfirmar_Click;
    }

    private void btnConfirmar_Click(object sender, EventArgs e)
    {
      try
      {
        if (!int.TryParse(txtID.Text, out int id))
        {
          MessageBox.Show("ID inválido");
          return;
        }

        var producto = Program.ProductoService.ObtenerPorId(id);
        if (producto == null)
        {
          MessageBox.Show("Producto no encontrado");
          return;
        }

        producto.Nombre = txtNombre.Text;
        producto.Precio = decimal.Parse(txtPrecio.Text);
        producto.Stock = int.Parse(txtStock.Text);

        Program.ProductoService.ActualizarProducto(producto);
        MessageBox.Show("Producto actualizado correctamente");
        this.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error: {ex.Message}");
      }
    }
  }
}
