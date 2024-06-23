using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;

namespace Domain.Core;

public class LocalityDomain : ILocalityDomain
{
    private readonly ILocalityRepository _localityRepository;

    public LocalityDomain(ILocalityRepository localityRepository)
    {
        _localityRepository = localityRepository;
    }

    #region Synchronous Methods
    public bool Insert(Locality locality)
    {
        return _localityRepository.Insert(locality);
    }
    public IEnumerable<Locality> GetAll()
    {
        return _localityRepository.GetAll();
    }
    public Locality Get(string LocalityId)
    {
        return _localityRepository.Get(LocalityId);
    }
    public bool Update(Locality locality)
    {
        return _localityRepository.Update(locality);
    }
    public bool Delete(string LocalityId)
    {
        return _localityRepository.Delete(LocalityId);
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Locality locality)
    {
        return await _localityRepository.InsertAsync(locality);
    }
    public async Task<IEnumerable<Locality>> GetAllAsync()
    {
        return await _localityRepository.GetAllAsync();
    }
    public async Task<Locality> GetAsync(string LocalityId)
    {
        return await _localityRepository.GetAsync(LocalityId);
    }
    public async Task<bool> UpdateAsync(Locality locality)
    {
        return await _localityRepository.UpdateAsync(locality);
    }
    public async Task<bool> DeleteAsync(string LocalityId)
    {
        return await _localityRepository.DeleteAsync(LocalityId);
    }
    #endregion
}