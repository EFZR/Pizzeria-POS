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

    #region Synchronous
    public Response<bool> Insert(UserDTO userDTO)
    {
        var response = new Response<bool>();
        try
        {
            var user = _mapper.Map<User>(userDTO);
            response.Data = _userDomain.Insert(user);
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

    public Response<UserDTO> Get(string UserId)
    {
        var response = new Response<UserDTO>();
        try
        {
            var user = _userDomain.Get(UserId);
            response.Data = _mapper.Map<UserDTO>(user);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "User Query Succesfully.";
                _logger.LogInformation("User Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public Response<IEnumerable<UserDTO>> GetAll()
    {
        var response = new Response<IEnumerable<UserDTO>>();
        try
        {
            var users = _userDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<UserDTO>>(users);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "User Query Succesfully.";
                _logger.LogInformation("User Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public Response<bool> Update(UserDTO userDTO)
    {
        var response = new Response<bool>();
        try
        {
            var user = _mapper.Map<User>(userDTO);
            response.Data = _userDomain.Update(user);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "User Updated Succesfully";
                _logger.LogInformation("User Updated Succesfully");
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

    public Response<bool> Delete(string UserId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _userDomain.Delete(UserId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "User deleted Succesfully.";
                _logger.LogInformation("User deleted Succesfully.");
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
    #endregion

    #region Asynchronous
    public async Task<Response<bool>> InsertAsync(UserDTO userDTO)
    {
        var response = new Response<bool>();
        try
        {
            var user = _mapper.Map<User>(userDTO);
            response.Data = await _userDomain.InsertAsync(user);
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

    public async Task<Response<UserDTO>> GetAsync(string UserId)
    {
        var response = new Response<UserDTO>();
        try
        {
            var user = await _userDomain.GetAsync(UserId);
            response.Data = _mapper.Map<UserDTO>(user);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "User Query Succesfully.";
                _logger.LogInformation("User Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<IEnumerable<UserDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<UserDTO>>();
        try
        {
            var users = await _userDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<UserDTO>>(users);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "User Query Succesfully.";
                _logger.LogInformation("User Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> UpdateAsync(UserDTO userDTO)
    {
        var response = new Response<bool>();
        try
        {
            var user = _mapper.Map<User>(userDTO);
            response.Data = await _userDomain.UpdateAsync(user);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "User Updated Succesfully";
                _logger.LogInformation("User Updated Succesfully");
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

    public async Task<Response<bool>> DeleteAsync(string UserId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _userDomain.DeleteAsync(UserId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "User deleted Succesfully.";
                _logger.LogInformation("User deleted Succesfully.");
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
    #endregion

}
