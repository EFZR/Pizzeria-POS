using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
// [Authorize]
public class UserController : ControllerBase
{
    private readonly IUserApplication _userApplication;
    public UserController(IUserApplication userApplication)
    {
        _userApplication = userApplication;
    }

    #region Synchronous Methods

    [HttpPost]
    public IActionResult Insert([FromBody] UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _userApplication.Insert(userDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert user." });
    }

    [HttpGet("userId")]
    public IActionResult Get(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest(new { error = "userId is required." });
        }

        var response = _userApplication.Get(userId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive user." });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _userApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive users." });
    }

    [HttpPut]
    public IActionResult Update([FromBody] UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _userApplication.Update(userDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update user." });
    }

    [HttpDelete("userId")]
    public IActionResult Delete(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest(new { error = "userId is required." });
        }

        var response = _userApplication.Delete(userId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete user." });
    }

    #endregion

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _userApplication.InsertAsync(userDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert user." });
    }

    [HttpGet("userId")]
    public async Task<IActionResult> AsyncGet(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest(new { error = "userId is required." });
        }

        var response = await _userApplication.GetAsync(userId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive user." });
    }

    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _userApplication.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive users." });
    }

    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _userApplication.UpdateAsync(userDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update user." });
    }

    [HttpDelete("userId")]
    public async Task<IActionResult> AsyncDelete(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest(new { error = "userId is required." });
        }

        var response = await _userApplication.DeleteAsync(userId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete user." });
    }

    #endregion
}
