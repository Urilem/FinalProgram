using System;
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
      
      IProductoRepository repository = CreateRepository();
      ProductoService = new ProductoService(repository);
      
      Application.Run(new FrmInicio());
    }

    private static IProductoRepository CreateRepository()
    {
      // Cambiar a "SQL" para usar base de datos
      string repositoryType = "Memory"; // o "SQL"

      // Usando switch tradicional compatible con C# 7.3
      switch (repositoryType)
      {
          case "SQL":
              return new ProductoRepositorySQL();
          case "Memory":
          default:
              return new ProductoRepositoryMemory();
      }
    }
  } 
}
