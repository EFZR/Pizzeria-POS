using Domain.Entity;

namespace Infrastructure.Interface;

public interface IProvinceRepository
{
    #region Synchronous Methods
    bool Insert(Province province);
    bool Update(Province province);
    bool Delete(string ProvinceId);
    Province Get(string ProvinceId);
    IEnumerable<Province> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(Province province);
    Task<bool> UpdateAsync(Province province);
    Task<bool> DeleteAsync(string ProvinceId);
    Task<Province> GetAsync(string ProvinceId);
    Task<IEnumerable<Province>> GetAllAsync();
    #endregion
}