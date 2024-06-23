using Microsoft.Data.Sqlite;

namespace Transversal.Common;
public interface IFactoryConnection
{
    SqliteConnection GetConnection { get; }
    void RecreateDatabase();
    void InitializeDatabase();
    void SeedData();
}