using Domain.Entity;

namespace Infrastructure.Interface;

public interface IOrderDetailRepository
{
    Task<bool> Insert(List<OrderDetail> orderDetails);
    Task<IEnumerable<OrderDetail>> GetAllByOrderId(string orderId);
}