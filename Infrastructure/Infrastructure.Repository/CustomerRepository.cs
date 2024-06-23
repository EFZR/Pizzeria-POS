using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class CustomerRespository : ICustomerRepository
{
    private readonly IFactoryConnection _factoryConnection;
    public CustomerRespository(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }

    #region Queries
    private readonly string INSERT = "INSERT INTO Customer (Cust_LocalId, Cust_FirstName, Cust_LastName, Cust_Phone, Cust_Email) VALUES (@Cust_LocalId, @Cust_FirstName, @Cust_LastName, @Cust_Phone, @Cust_Email);";
    private readonly string SELECT = "SELECT * FROM Customer;";
    private readonly string SELECT_BY_ID = "SELECT * FROM Customer WHERE Cust_Id = @Cust_Id;";
    private readonly string UPDATE = "UPDATE Customer SET Cust_LocalId = @Cust_LocalId, Cust_FirstName = @Cust_FirstName, Cust_LastName = @Cust_LastName, Cust_Phone = @Cust_Phone, Cust_Email = @Cust_Email WHERE Cust_Id = @Cust_Id;";
    private readonly string DELETE = "DELETE FROM Customer WHERE Cust_Id = @Cust_Id;";
    #endregion

    #region Synchronous Methods
    public bool Insert(Customer customer)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_LocalId", customer.Cust_LocalId);
        parameters.Add("Cust_FirstName", customer.Cust_FirstName);
        parameters.Add("Cust_LastName", customer.Cust_LastName);
        parameters.Add("Cust_Phone", customer.Cust_Phone);
        parameters.Add("Cust_Email", customer.Cust_Email);
        var result = connection.Execute(INSERT, parameters);
        return result > 0;
    }
    public IEnumerable<Customer> GetAll()
    {
        using var connection = _factoryConnection.GetConnection;
        var customer = connection.Query<Customer>(SELECT);
        return customer;
    }
    public Customer Get(string CustomerId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_Id", CustomerId);
        var customer = connection.QuerySingle<Customer>(SELECT_BY_ID, parameters);
        return customer;
    }
    public bool Update(Customer customer)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_Id", customer.Cust_Id);
        parameters.Add("Cust_LocalId", customer.Cust_LocalId);
        parameters.Add("Cust_FirstName", customer.Cust_FirstName);
        parameters.Add("Cust_LastName", customer.Cust_LastName);
        parameters.Add("Cust_Phone", customer.Cust_Phone);
        parameters.Add("Cust_Email", customer.Cust_Email);
        var result = connection.Execute(UPDATE, parameters);
        return result > 0;
    }
    public bool Delete(string CustomerId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_Id", CustomerId);
        var result = connection.Execute(DELETE, parameters);
        return result > 0;
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Customer customer)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_LocalId", customer.Cust_LocalId);
        parameters.Add("Cust_FirstName", customer.Cust_FirstName);
        parameters.Add("Cust_LastName", customer.Cust_LastName);
        parameters.Add("Cust_Phone", customer.Cust_Phone);
        parameters.Add("Cust_Email", customer.Cust_Email);
        var result = await connection.ExecuteAsync(INSERT, parameters);
        return result > 0;
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        using var connection = _factoryConnection.GetConnection;
        var customer = await connection.QueryAsync<Customer>(SELECT);
        return customer;
    }
    public async Task<Customer> GetAsync(string CustomerId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_Id", CustomerId);
        var customer = await connection.QuerySingleAsync<Customer>(SELECT_BY_ID, parameters);
        return customer;
    }
    public async Task<bool> UpdateAsync(Customer customer)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_Id", customer.Cust_Id);
        parameters.Add("Cust_LocalId", customer.Cust_LocalId);
        parameters.Add("Cust_FirstName", customer.Cust_FirstName);
        parameters.Add("Cust_LastName", customer.Cust_LastName);
        parameters.Add("Cust_Phone", customer.Cust_Phone);
        parameters.Add("Cust_Email", customer.Cust_Email);
        var result = await connection.ExecuteAsync(UPDATE, parameters);
        return result > 0;
    }
    public async Task<bool> DeleteAsync(string CustomerId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("Cust_Id", CustomerId);
        var result = await connection.ExecuteAsync(DELETE, parameters);
        return result > 0;
    }
    #endregion
}