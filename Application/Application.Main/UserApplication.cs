using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class UserApplication : IUserApplication
{
    private readonly IMapper _mapper;
    private readonly IUserDomain _userDomain;
    private readonly IAppLogger<UserApplication> _logger;

    public UserApplication(IMapper mapper, IUserDomain userDomain, IAppLogger<UserApplication> logger)
    {
        _userDomain = userDomain;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Response<UserDTO>> Authenticate(string email, string password)
    {
        var response = new Response<UserDTO>();
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            response.IsSuccess = false;
            response.Message = "Username and Password Required.";
            return response;
        }
        try
        {
            var user = await _userDomain.Authenticate(email, password);
            response.Data = _mapper.Map<UserDTO>(user);
            response.IsSuccess = true;
            response.Message = "Authentication succesfully.";
        }
        catch (InvalidOperationException)
        {
            response.IsSuccess = true;
            response.Message = "User not found.";
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<Response<bool>> CreateAccount(UserDTO userDTO)
    {
        var response = new Response<bool>();
        try
        {
            var user = _mapper.Map<User>(userDTO);
            response.Data = await _userDomain.CreateAccount(user);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "User Created Succesfully.";
                _logger.LogInformation("User Created Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }
}
