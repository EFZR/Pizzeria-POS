using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Service.PizzaPos.Helpers;
using Application.Interface;
using Application.DTO;
using Transversal.Common;

namespace Service.PizzaPos;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserApplication _userApplication;
    private readonly AppSettings _appSettings;
    public UserController(IUserApplication userApplication, IOptions<AppSettings> appSettings)
    {
        _userApplication = userApplication;
        _appSettings = appSettings.Value;
    }

    // TODO: Make an authDTO.
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] UserDTO userDTO)
    {
        try
        {
            if (userDTO.Email == null)
            {
                return BadRequest("User Empty.");
            }
            if (userDTO.Password == null)
            {
                return BadRequest("Password Empty.");
            }

            var response = await _userApplication.Authenticate(userDTO.Email, userDTO.Password);
            if (response.IsSuccess)
            {
                if (response.Data == null)
                {
                    return NotFound(response.Message);
                }
                else
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] UserDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _userApplication.CreateAccount(userDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert product." });
    }

    private string BuildToken(Response<UserDTO> userDTO)
    {
        if (_appSettings.Secret == null)
        {
            throw new Exception();
        }
        if (userDTO.Data == null)
        {
            throw new Exception();
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new(ClaimTypes.Name, userDTO.Data.Id.ToString()),
                }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.Audience
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}
