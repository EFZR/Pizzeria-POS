using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class LocalityController : ControllerBase
{
    private readonly ILocalityApplication _localityApplication;
    public LocalityController(ILocalityApplication localityApplication)
    {
        _localityApplication = localityApplication;
    }

    #region Synchronous Methods

    [HttpPost]
    public IActionResult Insert([FromBody] LocalityDTO localityDTO)
    {
        if (localityDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _localityApplication.Insert(localityDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert locality." });
    }

    [HttpGet("localityId")]
    public IActionResult Get(string localityId)
    {
        if (string.IsNullOrEmpty(localityId))
        {
            return BadRequest(new { error = "localityId is required." });
        }

        var response = _localityApplication.Get(localityId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive locality." });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _localityApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive localities." });
    }

    [HttpPut]
    public IActionResult Update([FromBody] LocalityDTO localityDTO)
    {
        if (localityDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _localityApplication.Update(localityDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update locality." });
    }

    [HttpDelete("localityId")]
    public IActionResult Delete(string localityId)
    {
        if (string.IsNullOrEmpty(localityId))
        {
            return BadRequest(new { error = "localityId is required." });
        }

        var response = _localityApplication.Delete(localityId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete locality." });
    }

    #endregion

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] LocalityDTO localityDTO)
    {
        if (localityDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _localityApplication.InsertAsync(localityDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert locality." });
    }

    [HttpGet("localityId")]
    public async Task<IActionResult> AsyncGet(string localityId)
    {
        if (string.IsNullOrEmpty(localityId))
        {
            return BadRequest(new { error = "localityId is required." });
        }

        var response = await _localityApplication.GetAsync(localityId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive locality." });
    }

    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _localityApplication.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive localities." });
    }

    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] LocalityDTO localityDTO)
    {
        if (localityDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _localityApplication.UpdateAsync(localityDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update locality." });
    }

    [HttpDelete("localityId")]
    public async Task<IActionResult> AsyncDelete(string localityId)
    {
        if (string.IsNullOrEmpty(localityId))
        {
            return BadRequest(new { error = "localityId is required." });
        }

        var response = await _localityApplication.DeleteAsync(localityId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete locality." });
    }

    #endregion
}
