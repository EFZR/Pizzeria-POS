using Domain.Entity;

namespace Domain.Interface;

public interface ILocalityDomain
{
    #region Synchronous Methods
    bool Insert(Locality locality);
    bool Update(Locality locality);
    bool Delete(string LocalityId);
    Locality Get(string LocalityId);
    IEnumerable<Locality> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(Locality locality);
    Task<bool> UpdateAsync(Locality locality);
    Task<bool> DeleteAsync(string LocalityId);
    Task<Locality> GetAsync(string LocalityId);
    Task<IEnumerable<Locality>> GetAllAsync();
    #endregion
}