using Domain.Entity;

namespace Domain.Interface;

public interface IProductDomain
{
    #region Synchronous Methods
    bool Insert(Product product);
    bool Update(Product product);
    bool Delete(string ProductId);
    Product Get(string ProductId);
    IEnumerable<Product> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(string ProductId);
    Task<Product> GetAsync(string ProductId);
    Task<IEnumerable<Product>> GetAllAsync();
    #endregion
}