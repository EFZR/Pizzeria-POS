using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;

namespace Domain.Core;

public class ProductDomain : IProductDomain
{
    private readonly IProductRepository _productRepository;

    public ProductDomain(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    #region Synchronous Methods
    public bool Insert(Product product)
    {
        return _productRepository.Insert(product);
    }
    public IEnumerable<Product> GetAll()
    {
        return _productRepository.GetAll();
    }
    public Product Get(string ProductId)
    {
        return _productRepository.Get(ProductId);
    }
    public bool Update(Product product)
    {
        return _productRepository.Update(product);
    }
    public bool Delete(string ProductId)
    {
        return _productRepository.Delete(ProductId);
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Product product)
    {
        return await _productRepository.InsertAsync(product);
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }
    public async Task<Product> GetAsync(string ProductId)
    {
        return await _productRepository.GetAsync(ProductId);
    }
    public async Task<bool> UpdateAsync(Product product)
    {
        return await _productRepository.UpdateAsync(product);
    }
    public async Task<bool> DeleteAsync(string ProductId)
    {
        return await _productRepository.DeleteAsync(ProductId);
    }
    #endregion
}