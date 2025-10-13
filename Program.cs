// Program.cs
namespace FinalProgram
{
    internal static class Program
    {
        public static ProductoService ProductoService { get; private set; }

        [STAThread]
        static void Main()
        {
            // Configurar el servicio con el repositorio en memoria
            var repository = new ProductoRepositoryMemory();
            ProductoService = new ProductoService(repository);

            ApplicationConfiguration.Initialize();
            Application.Run(new FrmInicio());
        }
    }
}
