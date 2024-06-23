using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;

namespace Domain.Core;

public class CustomerDomain : ICustomerDomain
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomain(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    #region Synchronous Methods
    public bool Insert(Customer customer)
    {
        return _customerRepository.Insert(customer);
    }
    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }
    public Customer Get(string CustomerId)
    {
        return _customerRepository.Get(CustomerId);
    }
    public bool Update(Customer customer)
    {
        return _customerRepository.Update(customer);
    }
    public bool Delete(string CustomerId)
    {
        return _customerRepository.Delete(CustomerId);
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Customer customer)
    {
        return await _customerRepository.InsertAsync(customer);
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }
    public async Task<Customer> GetAsync(string CustomerId)
    {
        return await _customerRepository.GetAsync(CustomerId);
    }
    public async Task<bool> UpdateAsync(Customer customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }
    public async Task<bool> DeleteAsync(string CustomerId)
    {
        return await _customerRepository.DeleteAsync(CustomerId);
    }
    #endregion
}