using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface ICountryApplication
{
    #region Synchronous Methods
    Response<bool> Insert(CountryDTO countryDTO);
    Response<bool> Update(CountryDTO country);
    Response<bool> Delete(string CountryId);
    Response<CountryDTO> Get(string CountryId);
    Response<IEnumerable<CountryDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(CountryDTO country);
    Task<Response<bool>> UpdateAsync(CountryDTO country);
    Task<Response<bool>> DeleteAsync(string CountryId);
    Task<Response<CountryDTO>> GetAsync(string CountryId);
    Task<Response<IEnumerable<CountryDTO>>> GetAllAsync();
    #endregion
}
