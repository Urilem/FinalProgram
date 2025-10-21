using System;
using System.Data.SqlClient;

class TestConnection 
{
    static void Main()
    {
        string connectionString = "Server=localhost,1433;Database=master;User Id=sa;Password=YourStrong!Password123;TrustServerCertificate=true;";
        
        try 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("✅ ¡CONEXIÓN EXITOSA A SQL SERVER!");
                
                var command = new SqlCommand("SELECT @@VERSION", connection);
                var version = command.ExecuteScalar();
                Console.WriteLine($"SQL Server: {version}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error de conexión: {ex.Message}");
        }
    }
}
