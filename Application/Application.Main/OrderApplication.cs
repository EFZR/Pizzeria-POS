using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class OrderApplication : IOrderApplication
{
    private readonly IMapper _mapper;
    private readonly IOrderDomain _orderDomain;
    private readonly IAppLogger<ProductApplication> _logger;

    public OrderApplication(IMapper mapper, IOrderDomain orderDomain, IAppLogger<ProductApplication> logger)
    {
        _orderDomain = orderDomain;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<Response<OrderWithDetailsDTO>> PlaceOrder(CreateOrderWithDetailsDTO createOrderWithDetailsDTO, string userId)
    {
        var response = new Response<OrderWithDetailsDTO>();
        try
        {
            var order = await _orderDomain.PlaceOrder(createOrderWithDetailsDTO, userId);
            response.Data = _mapper.Map<OrderWithDetailsDTO>(order);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Order placed correctly";
                _logger.LogInformation("Order placed correctly");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }
}
