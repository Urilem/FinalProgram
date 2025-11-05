using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FinalProgram.AccesoDatos
{
  public class ConexionBD
  {
    private readonly string _cadenaConexion;

    public ConexionBD()
    {
      _cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
          Console.WriteLine("✅ Conexión a la base de datos exitosa");
        }
        catch (Exception ex)
        {
          throw new Exception($"❌ Error de conexión: {ex.Message}");
        }
      }
    }
  }
}
