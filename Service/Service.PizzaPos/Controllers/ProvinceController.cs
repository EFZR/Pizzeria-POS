using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class ProvinceController : ControllerBase
{
    private readonly IProvinceApplication _provinceApplication;
    public ProvinceController(IProvinceApplication provinceApplication)
    {
        _provinceApplication = provinceApplication;
    }

    #region Synchronous Methods

    [HttpPost]
    public IActionResult Insert([FromBody] ProvinceDTO provinceDTO)
    {
        if (provinceDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _provinceApplication.Insert(provinceDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert province." });
    }

    [HttpGet("provinceId")]
    public IActionResult Get(string provinceId)
    {
        if (string.IsNullOrEmpty(provinceId))
        {
            return BadRequest(new { error = "provinceId is required." });
        }

        var response = _provinceApplication.Get(provinceId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive province." });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _provinceApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive provinces." });
    }

    [HttpPut]
    public IActionResult Update([FromBody] ProvinceDTO provinceDTO)
    {
        if (provinceDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _provinceApplication.Update(provinceDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update province." });
    }

    [HttpDelete("provinceId")]
    public IActionResult Delete(string provinceId)
    {
        if (string.IsNullOrEmpty(provinceId))
        {
            return BadRequest(new { error = "provinceId is required." });
        }

        var response = _provinceApplication.Delete(provinceId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete province." });
    }

    #endregion

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] ProvinceDTO provinceDTO)
    {
        if (provinceDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _provinceApplication.InsertAsync(provinceDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert province." });
    }

    [HttpGet("provinceId")]
    public async Task<IActionResult> AsyncGet(string provinceId)
    {
        if (string.IsNullOrEmpty(provinceId))
        {
            return BadRequest(new { error = "provinceId is required." });
        }

        var response = await _provinceApplication.GetAsync(provinceId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive province." });
    }

    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _provinceApplication.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive provinces." });
    }

    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] ProvinceDTO provinceDTO)
    {
        if (provinceDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _provinceApplication.UpdateAsync(provinceDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update province." });
    }

    [HttpDelete("provinceId")]
    public async Task<IActionResult> AsyncDelete(string provinceId)
    {
        if (string.IsNullOrEmpty(provinceId))
        {
            return BadRequest(new { error = "provinceId is required." });
        }

        var response = await _provinceApplication.DeleteAsync(provinceId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete province." });
    }

    #endregion
}
