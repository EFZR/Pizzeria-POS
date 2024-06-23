using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly IFactoryConnection _factoryConnection;
    public OrderDetailRepository(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }

    #region Queries
    private readonly string INSERT = "INSERT INTO OrderDetail (OD_OrdId, OD_ProdId, OD_Quantity, OD_Price) VALUES (@OD_OrdId, @OD_ProdId, @OD_Quantity, @OD_Price);";
    private readonly string SELECT_BY_ORDERID = "SELECT * FROM OrderDetail WHERE OD_OrdId = @OD_OrdId ;";
    #endregion

    public async Task<bool> Insert(List<OrderDetail> orderDetails)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters();
        var result = await connection.ExecuteAsync(INSERT, orderDetails);
        return result > 0;
    }

    public async Task<IEnumerable<OrderDetail>> GetAllByOrderId(string orderId)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters();
        parameters.Add("OD_OrdId", orderId);
        var order = await connection.QueryAsync<OrderDetail>(SELECT_BY_ORDERID, parameters);
        return order;
    }
}