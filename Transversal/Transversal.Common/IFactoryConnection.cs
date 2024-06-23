using System.Data.SqlClient;

namespace Transversal.Common;
public interface IFactoryConnection
{
    SqlConnection GetConnection { get; }
    void RecreateDatabase();
    void InitializeDatabase();
    void SeedData();
}