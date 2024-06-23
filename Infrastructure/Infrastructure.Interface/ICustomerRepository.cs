using Domain.Entity;

namespace Infrastructure.Interface;

public interface ICustomerRepository
{
    #region Synchronous Methods
    bool Insert(Customer customer);
    bool Update(Customer customer);
    bool Delete(string CustomerId);
    Customer Get(string CustomerId);
    IEnumerable<Customer> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(Customer customer);
    Task<bool> UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(string CustomerId);
    Task<Customer> GetAsync(string CustomerId);
    Task<IEnumerable<Customer>> GetAllAsync();
    #endregion
}