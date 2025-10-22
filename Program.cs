using System;
using System.IO;
using System.Windows.Forms;

namespace FinalProgram
{
  internal static class Program
  {
    public static ProductoService ProductoService { get; private set; }

    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      
      // Instanciar directamente el repositorio SQL
      IProductoRepository repository = new ProductoRepositorySQL();
      ProductoService = new ProductoService(repository);
      
      Application.Run(new FrmInicio());
    }
  } 
}
