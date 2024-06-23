using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;

namespace Domain.Core;

public class CountryDomain : ICountryDomain
{
    private readonly ICountryRepository _countryRepository;

    public CountryDomain(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    #region Synchronous Methods
    public bool Insert(Country country)
    {
        return _countryRepository.Insert(country);
    }
    public IEnumerable<Country> GetAll()
    {
        return _countryRepository.GetAll();
    }
    public Country Get(string CountryId)
    {
        return _countryRepository.Get(CountryId);
    }
    public bool Update(Country country)
    {
        return _countryRepository.Update(country);
    }
    public bool Delete(string CountryId)
    {
        return _countryRepository.Delete(CountryId);
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Country country)
    {
        return await _countryRepository.InsertAsync(country);
    }
    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _countryRepository.GetAllAsync();
    }
    public async Task<Country> GetAsync(string CountryId)
    {
        return await _countryRepository.GetAsync(CountryId);
    }
    public async Task<bool> UpdateAsync(Country country)
    {
        return await _countryRepository.UpdateAsync(country);
    }
    public async Task<bool> DeleteAsync(string CountryId)
    {
        return await _countryRepository.DeleteAsync(CountryId);
    }
    #endregion
}