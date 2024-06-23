using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Transversal.Common;

namespace Infrastructure.Data;

public class FactoryConnection : IFactoryConnection
{
    private readonly IConfiguration _configuration;
    public FactoryConnection(IConfiguration configuration)
    {
        _configuration = configuration;
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
}
