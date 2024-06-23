using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Transversal.Common;

namespace Infrastructure.Data;

// TODO: Available developer mode for sqlite db and production mode for a sqlserver db.

public class FactoryConnection : IFactoryConnection
{
    private readonly IConfiguration _configuration;
    private readonly string _contentRootPath;

    public FactoryConnection(IConfiguration configuration, IHostingEnvironment env)
    {
        _configuration = configuration;
        _contentRootPath = env.ContentRootPath;
    }

    public SqlConnection GetConnection
    {
        get
        {
            var connectionString = _configuration.GetConnectionString("db_Connection");
            var sqlConnection = new SqlConnection(connectionString) ?? throw new Exception("Connection Error.");
            sqlConnection.Open();
            return sqlConnection;
        }
    }

    public void RecreateDatabase()
    {
        ExecuteSqlScript("00-recreate-db.sql");
    }

    public void InitializeDatabase()
    {
        ExecuteSqlScript("01-create-schema.sql");
    }

    public void SeedData()
    {
        ExecuteSqlScript("02-dev-seed.sql");
    }

    private void ExecuteSqlScript(string scriptFileName)
    {
        string scriptPath = Path.Combine(_contentRootPath, "scripts", "sqlserver", scriptFileName);
        var connectionString = _configuration.GetConnectionString("db_connection");

        if (!File.Exists(scriptPath))
        {
            throw new FileNotFoundException($"SQL file {scriptFileName} not found at path: {scriptPath}");
        }

        string sqlCommands = File.ReadAllText(scriptPath);
        var commands = sqlCommands.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        foreach (var commandText in commands)
        {
            if (!string.IsNullOrWhiteSpace(commandText))
            {
                using var command = connection.CreateCommand();
                command.CommandText = commandText;
                command.ExecuteNonQuery();
            }
        }
    }
}
