using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
// [Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeApplication _employeeApplication;
    public EmployeeController(IEmployeeApplication employeeApplication)
    {
        _employeeApplication = employeeApplication;
    }

    #region Synchronous Methods

    [HttpPost]
    public IActionResult Insert([FromBody] EmployeeDTO employeeDTO)
    {
        if (employeeDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _employeeApplication.Insert(employeeDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert employee." });
    }

    [HttpGet("employeeId")]
    public IActionResult Get(string employeeId)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            return BadRequest(new { error = "employeeId is required." });
        }

        var response = _employeeApplication.Get(employeeId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve employee." });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _employeeApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve employees." });
    }

    [HttpPut]
    public IActionResult Update([FromBody] EmployeeDTO employeeDTO)
    {
        if (employeeDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _employeeApplication.Update(employeeDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update employee."});
    }

    [HttpDelete("employeeId")]
    public IActionResult Delete(string employeeId)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            return BadRequest(new { error = "employeeId is required." });
        }

        var response = _employeeApplication.Delete(employeeId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete employee."});
    }

    #endregion

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] EmployeeDTO employeeDTO)
    {
        if (employeeDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _employeeApplication.InsertAsync(employeeDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert employee."});
    }

    [HttpGet("employeeId")]
    public async Task<IActionResult> AsyncGet(string employeeId)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            return BadRequest(new { error = "employeeId is required." });
        }

        var response = await _employeeApplication.GetAsync(employeeId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve employee."});
    }

    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _employeeApplication.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve employees."});
    }

    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] EmployeeDTO employeeDTO)
    {
        if (employeeDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _employeeApplication.UpdateAsync(employeeDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update employee."});
    }

    [HttpDelete("employeeId")]
    public async Task<IActionResult> AsyncDelete(string employeeId)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            return BadRequest(new { error = "employeeId is required." });
        }

        var response = await _employeeApplication.DeleteAsync(employeeId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete employee."});
    }

    #endregion

}
