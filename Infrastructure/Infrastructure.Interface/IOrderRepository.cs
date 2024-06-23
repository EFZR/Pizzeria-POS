using Domain.Entity;

namespace Infrastructure.Interface;

public interface IOrderRepository
{
    Task<bool> Insert(Order order);
    Task<Order> Get(string Ord_BillNumber);
}
