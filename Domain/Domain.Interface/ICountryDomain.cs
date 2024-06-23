using Domain.Entity;

namespace Domain.Interface;

public interface ICountryDomain
{
    #region Synchronous Methods
    bool Insert(Country country);
    bool Update(Country country);
    bool Delete(string CountryId);
    Country Get(string CountryId);
    IEnumerable<Country> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(Country country);
    Task<bool> UpdateAsync(Country country);
    Task<bool> DeleteAsync(string CountryId);
    Task<Country> GetAsync(string CountryId);
    Task<IEnumerable<Country>> GetAllAsync();
    #endregion
}