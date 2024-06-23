using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductApplication _productApplication;
    public ProductController(IProductApplication productApplication)
    {
        _productApplication = productApplication;
    }

    #region Synchronous Methods

    [HttpPost]
    public IActionResult Insert([FromBody] ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _productApplication.Insert(productDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert product." });
    }

    [HttpGet("productId")]
    public IActionResult Get(string productId)
    {
        if (string.IsNullOrEmpty(productId))
        {
            return BadRequest(new { error = "productId is required." });
        }

        var response = _productApplication.Get(productId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive product." });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _productApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive products." });
    }

    [HttpPut]
    public IActionResult Update([FromBody] ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = _productApplication.Update(productDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update product." });
    }

    [HttpDelete("productId")]
    public IActionResult Delete(string productId)
    {
        if (string.IsNullOrEmpty(productId))
        {
            return BadRequest(new { error = "productId is required." });
        }

        var response = _productApplication.Delete(productId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete product." });
    }

    #endregion

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _productApplication.InsertAsync(productDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert product." });
    }

    [HttpGet("productId")]
    public async Task<IActionResult> AsyncGet(string productId)
    {
        if (string.IsNullOrEmpty(productId))
        {
            return BadRequest(new { error = "productId is required." });
        }

        var response = await _productApplication.GetAsync(productId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive product." });
    }

    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _productApplication.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrive products." });
    }

    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _productApplication.UpdateAsync(productDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update product." });
    }

    [HttpDelete("productId")]
    public async Task<IActionResult> AsyncDelete(string productId)
    {
        if (string.IsNullOrEmpty(productId))
        {
            return BadRequest(new { error = "productId is required." });
        }

        var response = await _productApplication.DeleteAsync(productId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete product." });
    }

    #endregion

}
