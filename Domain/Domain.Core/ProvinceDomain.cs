using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;

namespace Domain.Core;

public class ProvinceDomain : IProvinceDomain
{
    private readonly IProvinceRepository _provinceRepository;

    public ProvinceDomain(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    #region Synchronous Methods
    public bool Insert(Province province)
    {
        return _provinceRepository.Insert(province);
    }
    public IEnumerable<Province> GetAll()
    {
        return _provinceRepository.GetAll();
    }
    public Province Get(string ProvinceId)
    {
        return _provinceRepository.Get(ProvinceId);
    }
    public bool Update(Province province)
    {
        return _provinceRepository.Update(province);
    }
    public bool Delete(string ProvinceId)
    {
        return _provinceRepository.Delete(ProvinceId);
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Province province)
    {
        return await _provinceRepository.InsertAsync(province);
    }
    public async Task<IEnumerable<Province>> GetAllAsync()
    {
        return await _provinceRepository.GetAllAsync();
    }
    public async Task<Province> GetAsync(string ProvinceId)
    {
        return await _provinceRepository.GetAsync(ProvinceId);
    }
    public async Task<bool> UpdateAsync(Province province)
    {
        return await _provinceRepository.UpdateAsync(province);
    }
    public async Task<bool> DeleteAsync(string ProvinceId)
    {
        return await _provinceRepository.DeleteAsync(ProvinceId);
    }
    #endregion
}