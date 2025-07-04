using Microsoft.Data.SqlClient;
using Dapper;

public static class BD{
    private static string_connectionString = @"Server=localhost;DataBase=LaAUF;Integrated Security=True;TrustServerCertificate=True";

    public Integrante LevantarIntegrante(string integrante){
        Integrante integrante = null;
        using(SqlConnction connection = new SqlConnction(_connectionString)){
            string query = "...;
            integrante= connection.QueryFirstOrDefault<Integrante>(query new {});
        }
        return integrante;
    }
}