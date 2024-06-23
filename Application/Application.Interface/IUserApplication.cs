using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IUserApplication
{
    Task<Response<bool>> CreateAccount(UserDTO userDTO);
    Task<Response<UserDTO>> Authenticate(string email, string password);
}
