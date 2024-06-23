using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IOrderApplication
{
    Task<Response<OrderWithDetailsDTO>> PlaceOrder(CreateOrderWithDetailsDTO createOrderWithDetailsDTO, string userId);
}
