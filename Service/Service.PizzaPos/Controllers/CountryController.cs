using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CountryController : ControllerBase
{
    private readonly ICountryApplication _countryApplication;
    public CountryController(ICountryApplication countryApplication)
    {
        _countryApplication = countryApplication;
    }

    #region Synchronous Methods

    [HttpPost]
    public IActionResult Insert([FromBody] CountryDTO countryDTO)
    {
        if (countryDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _countryApplication.Insert(countryDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert country."});
    }

    [HttpGet("countryId")]
    public IActionResult Get(string countryId)
    {
        if (string.IsNullOrEmpty(countryId))
        {
            return BadRequest(new { error = "CountryId is required." });
        }

        var response = _countryApplication.Get(countryId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve country."});
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _countryApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve countries."});
    }

    [HttpPut]
    public IActionResult Update([FromBody] CountryDTO countryDTO)
    {
        if (countryDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _countryApplication.Update(countryDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update country."});
    }

    [HttpDelete("countryId")]
    public IActionResult Delete(string countryId)
    {
        if (string.IsNullOrEmpty(countryId))
        {
            return BadRequest(new { error = "CountryId is required." });
        }

        var response = _countryApplication.Delete(countryId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete country."});
    }

    #endregion

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] CountryDTO countryDTO)
    {
        if (countryDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _countryApplication.InsertAsync(countryDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert country."});
    }

    [HttpGet("countryId")]
    public async Task<IActionResult> AsyncGet(string countryId)
    {
        if (string.IsNullOrEmpty(countryId))
        {
            return BadRequest(new { error = "CountryId is required." });
        }

        var response = await _countryApplication.GetAsync(countryId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve country."});
    }

    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _countryApplication.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve countries."});
    }

    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] CountryDTO countryDTO)
    {
        if (countryDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _countryApplication.UpdateAsync(countryDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update country."});
    }

    [HttpDelete("countryId")]
    public async Task<IActionResult> AsyncDelete(string countryId)
    {
        if (string.IsNullOrEmpty(countryId))
        {
            return BadRequest(new { error = "CountryId is required." });
        }

        var response = await _countryApplication.DeleteAsync(countryId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete country."});
    }

    #endregion
}
