using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;
using System.Security.Claims;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IOrderApplication _orderApplication;
    public OrderController(IOrderApplication orderApplication)
    {
        _orderApplication = orderApplication;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] CreateOrderWithDetailsDTO createOrderWithDetailsDTO)
    {
        if (createOrderWithDetailsDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var userId = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userId == null)
        {
            return Unauthorized(new { error = "Web Token no valid." });
        }

        var response = await _orderApplication.PlaceOrder(createOrderWithDetailsDTO, userId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to place order." });
    }
}
