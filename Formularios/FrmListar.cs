using System;
using System.Windows.Forms;
using FinalProgram.Modelos;
using FinalProgram.Servicios;

namespace FinalProgram.Formularios
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
      var productos = Program.ServicioProductos.ObtenerTodosLosProductos();
      gridProductos.DataSource = productos;
    }
  }
}
