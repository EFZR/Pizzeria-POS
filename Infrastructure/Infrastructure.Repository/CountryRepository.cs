using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class CountryRespository : ICountryRepository
{
    private readonly IFactoryConnection _factoryConnection;
    public CountryRespository(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }

    #region Queries
    private readonly string INSERT = "INSERT INTO Country (Country_Name) VALUES (@Country_Name);";
    private readonly string SELECT = "SELECT * FROM Country";
    private readonly string SELECT_BY_ID = "SELECT * FROM Country WHERE Country_Id = @Country_Id;";
    private readonly string UPDATE = "UPDATE Country SET Country_Name = @Country_Name WHERE Country_Id = @Country_Id;";
    private readonly string DELETE = "DELETE FROM Country WHERE Country_Id = @Country_Id;";
    #endregion

    #region Synchronous Methods
    public bool Insert(Country country)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Name", country.Country_Name);
        var result = connection.Execute(INSERT, parameters);
        return result > 0;
    }
    public IEnumerable<Country> GetAll()
    {
        using var connection = _factoryConnection.GetConnection;
        var country = connection.Query<Country>(SELECT);
        return country;
    }
    public Country Get(string CountryId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Id", CountryId);
        var country = connection.QuerySingle<Country>(SELECT_BY_ID, parameters);
        return country;
    }
    public bool Update(Country country)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Id", country.Country_Id);
        parameters.Add("Country_Name", country.Country_Name);
        var result = connection.Execute(UPDATE, parameters);
        return result > 0;
    }
    public bool Delete(string CountryId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Id", CountryId);
        var result = connection.Execute(DELETE, parameters);
        return result > 0;
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Country country)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Name", country.Country_Name);
        var result = await connection.ExecuteAsync(INSERT, parameters);
        return result > 0;
    }
    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        using var connection = _factoryConnection.GetConnection;
        var country = await connection.QueryAsync<Country>(SELECT);
        return country;
    }
    public async Task<Country> GetAsync(string CountryId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Id", CountryId);
        var country = await connection.QuerySingleAsync<Country>(SELECT_BY_ID, parameters);
        return country;
    }
    public async Task<bool> UpdateAsync(Country country)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Id", country.Country_Id);
        parameters.Add("Country_Name", country.Country_Name);
        var result = await connection.ExecuteAsync(UPDATE, parameters);
        return result > 0;
    }
    public async Task<bool> DeleteAsync(string CountryId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Country_Id", CountryId);
        var result = await connection.ExecuteAsync(DELETE, parameters);
        return result > 0;
    }
    #endregion
}