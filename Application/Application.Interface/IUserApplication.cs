using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IUserApplication
{
    #region Synchronous Methods
    Response<bool> Insert(UserDTO userDTO);
    Response<bool> Update(UserDTO userDTO);
    Response<bool> Delete(string UserId);
    Response<UserDTO> Get(string UserId);
    Response<IEnumerable<UserDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(UserDTO userDTO);
    Task<Response<bool>> UpdateAsync(UserDTO userDTO);
    Task<Response<bool>> DeleteAsync(string UserId);
    Task<Response<UserDTO>> GetAsync(string UserId);
    Task<Response<IEnumerable<UserDTO>>> GetAllAsync();
    #endregion
}
