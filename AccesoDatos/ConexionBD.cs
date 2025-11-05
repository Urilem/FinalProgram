using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProgram.AccesoDatos
{
  public class ConexionBD
  {
    private readonly string _cadenaConexion;

    public ConexionBD()
    {
      try
      {
        var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];

        if (connectionString == null)
        {
          throw new Exception("No se encontró la cadena de conexión 'DefaultConnection' en App.config");
        }

        _cadenaConexion = connectionString.ConnectionString;
        Console.WriteLine("✅ Cadena de conexión cargada correctamente");
      }
      catch (Exception ex)
      {
        MessageBox.Show($"❌ Error al cargar la conexión: {ex.Message}\n\n" +
                      "Verifica que el archivo App.config esté configurado correctamente.",
                      "Error de Configuración",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw;
      }
    }

    public SqlConnection ObtenerConexion()
    {
      return new SqlConnection(_cadenaConexion);
    }

    public void ProbarConexion()
    {
      using (var conexion = ObtenerConexion())
      {
        try
        {
          conexion.Open();
          MessageBox.Show("✅ Conexión a la base de datos exitosa",
                        "Conexión Exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (SqlException ex)
        {
          string mensajeError = $"❌ Error de conexión SQL: {ex.Message}\n\n";

          // Mensajes más específicos según el error
          if (ex.Number == 53 || ex.Number == -1)
            mensajeError += "No se puede conectar al servidor. Verifica que:\n" +
                          "• SQL Server esté ejecutándose\n" +
                          "• El puerto 1433 esté abierto\n" +
                          "• El nombre del servidor sea correcto";
          else if (ex.Number == 18456)
            mensajeError += "Error de autenticación. Verifica usuario y contraseña.";
          else if (ex.Number == 4060)
            mensajeError += "La base de datos no existe. Ejecuta el script de creación.";

          MessageBox.Show(mensajeError, "Error de Conexión a BD",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
          throw;
        }
        catch (Exception ex)
        {
          MessageBox.Show($"❌ Error general: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
          throw;
        }
      }
    }
  }
}
