using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly IFactoryConnection _factoryConnection;
    public OrderRepository(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }

    #region Queries
    private readonly string INSERT = "INSERT INTO `Order` (Ord_EmpId, Ord_CustId, Ord_Date, Ord_BillNumber, Ord_Total) VALUES (@Ord_EmpId, @Ord_CustId, @Ord_Date, @Ord_BillNumber, @Ord_Total);";
    private readonly string SELECT_BY_BILLNUMBER = "SELECT * FROM `Order` WHERE Ord_BillNumber = @Ord_BillNumber;";
    #endregion

    public async Task<bool> Insert(Order order)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters();
        parameters.Add("@Ord_EmpId", order.Ord_EmpId);
        parameters.Add("@Ord_CustId", order.Ord_CustId);
        parameters.Add("@Ord_Date", order.Ord_Date);
        parameters.Add("@Ord_BillNumber", order.Ord_BillNumber);
        parameters.Add("@Ord_Total", order.Ord_Total);
        var result = await connection.ExecuteAsync(INSERT, parameters);
        return result > 0;
    }

    public async Task<Order> Get(string Ord_BillNumber)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters();
        parameters.Add("Ord_BillNumber", Ord_BillNumber);
        var order = await connection.QuerySingleAsync<Order>(SELECT_BY_BILLNUMBER, parameters);
        return order;
    }
}