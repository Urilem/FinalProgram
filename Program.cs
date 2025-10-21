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
      
      IProductoRepository repository = CreateRepository();
      ProductoService = new ProductoService(repository);
      
      Application.Run(new FrmInicio());
    }

    private static IProductoRepository CreateRepository()
    {
      string repositoryType = "Memory"; // Valor por defecto

      try
      {
        // Leer el archivo config.txt
        if (File.Exists("config.txt"))
        {
          string[] lines = File.ReadAllLines("config.txt");
          foreach (string line in lines)
          {
            // Ignorar comentarios y líneas vacías
            if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
              continue;

            // Buscar la línea que comienza con "RepositoryType="
            if (line.StartsWith("RepositoryType="))
            {
              repositoryType = line.Substring("RepositoryType=".Length).Trim();
              break;
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error leyendo config.txt: {ex.Message}. Usando repositorio en memoria por defecto.");
        repositoryType = "Memory";
      }

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
