using System;
using System.Windows.Forms;

namespace FinalProgram
{
  public partial class FrmListar : Form
  {
    public FrmListar()
    {
      InitializeComponent();
      btnVolver.Click += (s, e) => this.Close();
      
      CargarProductos();
    }

    private void CargarProductos()
    {
      var productos = Program.ProductoService.ObtenerTodos();
      gridProductos.DataSource = productos;
    }
  }
}
