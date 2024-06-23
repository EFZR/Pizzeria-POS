using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CustomerController : ControllerBase
{
    private readonly ICustomerApplication _customerApplication;
    public CustomerController(ICustomerApplication customerApplication)
    {
        _customerApplication = customerApplication;
    }

    #region Synchronous Methods

    [HttpPost]
    public IActionResult Insert([FromBody] CustomerDTO customerDTO)
    {
        if (customerDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _customerApplication.Insert(customerDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert customer."});
    }

    [HttpGet("customerId")]
    public IActionResult Get(string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest(new { error = "CustomerId is required." });
        }

        var response = _customerApplication.Get(customerId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive customer."});
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _customerApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive customers."});
    }

    [HttpPut]
    public IActionResult Update([FromBody] CustomerDTO customerDTO)
    {
        if (customerDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _customerApplication.Update(customerDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update customer."});
    }

    [HttpDelete("customerId")]
    public IActionResult Delete(string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest(new { error = "CustomerId is required." });
        }

        var response = _customerApplication.Delete(customerId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete customer."});
    }

    #endregion

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] CustomerDTO customerDTO)
    {
        if (customerDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _customerApplication.InsertAsync(customerDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert customer."});
    }

    [HttpGet("customerId")]
    public async Task<IActionResult> AsyncGet(string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest(new { error = "CustomerId is required." });
        }

        var response = await _customerApplication.GetAsync(customerId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive customer."});
    }

    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _customerApplication.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive customers."});
    }

    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] CustomerDTO customerDTO)
    {
        if (customerDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _customerApplication.UpdateAsync(customerDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update customer."});
    }

    [HttpDelete("customerId")]
    public async Task<IActionResult> AsyncDelete(string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest(new { error = "CustomerId is required." });
        }

        var response = await _customerApplication.DeleteAsync(customerId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete customer."});
    }

    #endregion

}
