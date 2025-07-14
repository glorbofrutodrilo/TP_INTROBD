using Microsoft.Data.SqlClient;
using Dapper;

public static class BD{
    private static string _connectionString = @"Server=localhost;Database=LaAUF;Integrated Security=True;TrustServerCertificate=True;";
    
    public static Integrante LevantarIntegrante(string nombreOEmail, string password)
    {
        Integrante miIntegrante = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Persona WHERE Nombre = @INombre AND Password = @IPassword";
            miIntegrante = connection.QueryFirstOrDefault<Integrante>(query, new { INombre = nombreOEmail, IPassword = password });
        }
        return miIntegrante;
    }
}