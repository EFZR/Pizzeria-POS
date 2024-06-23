using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Transversal.Common;

namespace Infrastructure.Data;

public class FactoryConnection : IFactoryConnection
{
    private readonly IConfiguration _configuration;
    private readonly string _contentRootPath;
    public FactoryConnection(IConfiguration configuration, IHostingEnvironment env)
    {
        _configuration = configuration;
        _contentRootPath = env.ContentRootPath;
    }
    public SqliteConnection GetConnection
    {
        get
        {
            var connectionString = _configuration.GetConnectionString("db_connection");
            var sqliteConnection = new SqliteConnection(connectionString) ?? throw new Exception("Connection Error.");
            sqliteConnection.Open();
            return sqliteConnection;
        }
    }

    public void RecreateDatabase() {
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
        string scriptPath = Path.Combine(_contentRootPath, "scripts", "sqlite", scriptFileName);
        var connectionString = _configuration.GetConnectionString("db_connection");

        if (!File.Exists(scriptPath))
        {
            throw new FileNotFoundException($"SQL file {scriptFileName} not found at path: {scriptPath}");
        }

        string sqlCommands = File.ReadAllText(scriptPath);
        var commands = sqlCommands.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        using var connection = new SqliteConnection(connectionString);
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
