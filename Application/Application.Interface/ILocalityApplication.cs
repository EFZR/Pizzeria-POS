using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface ILocalityApplication
{
    #region Synchronous Methods
    Response<bool> Insert(LocalityDTO localityDTO);
    Response<bool> Update(LocalityDTO localityDTO);
    Response<bool> Delete(string LocalityId);
    Response<LocalityDTO> Get(string LocalityId);
    Response<IEnumerable<LocalityDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(LocalityDTO localityDTO);
    Task<Response<bool>> UpdateAsync(LocalityDTO localityDTO);
    Task<Response<bool>> DeleteAsync(string LocalityId);
    Task<Response<LocalityDTO>> GetAsync(string LocalityId);
    Task<Response<IEnumerable<LocalityDTO>>> GetAllAsync();
    #endregion
}
