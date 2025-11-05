using System;
using System.Windows.Forms;
using FinalProgram.AccesoDatos;
using FinalProgram.Servicios;

namespace FinalProgram
{
  internal static class Program
  {
    public static ServicioProductos ServicioProductos { get; private set; }
    public static ServicioVentas ServicioVentas { get; private set; }

    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Configurar los servicios
      IRepositorioProductos repositorio = new RepositorioProductosSQL();
      ServicioProductos = new ServicioProductos(repositorio);
      ServicioVentas = new ServicioVentas(repositorio);

      Application.Run(new Formularios.FrmInicio());
    }
  }
}
