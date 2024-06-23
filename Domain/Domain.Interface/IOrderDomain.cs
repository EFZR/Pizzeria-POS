using Domain.Entity;
using Application.DTO;

namespace Domain.Interface;

public interface IOrderDomain
{
    Task<OrderWithDetails> PlaceOrder(CreateOrderWithDetailsDTO createOrderWithDetailsDTO, string userId);
}