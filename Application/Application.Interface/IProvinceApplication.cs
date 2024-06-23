using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IProvinceApplication
{
    #region Synchronous Methods
    Response<bool> Insert(ProvinceDTO provinceDTO);
    Response<bool> Update(ProvinceDTO provinceDTO);
    Response<bool> Delete(string ProvinceId);
    Response<ProvinceDTO> Get(string ProvinceId);
    Response<IEnumerable<ProvinceDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(ProvinceDTO provinceDTO);
    Task<Response<bool>> UpdateAsync(ProvinceDTO provinceDTO);
    Task<Response<bool>> DeleteAsync(string ProvinceId);
    Task<Response<ProvinceDTO>> GetAsync(string ProvinceId);
    Task<Response<IEnumerable<ProvinceDTO>>> GetAllAsync();
    #endregion
}
