using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class ProductApplication : IProductApplication
{
    private readonly IMapper _mapper;
    private readonly IProductDomain _productDomain;
    private readonly IAppLogger<ProductApplication> _logger;

    public ProductApplication(IMapper mapper, IProductDomain productDomain, IAppLogger<ProductApplication> logger)
    {
        _productDomain = productDomain;
        _mapper = mapper;
        _logger = logger;
    }

    #region Synchronous Methods
    public Response<bool> Insert(ProductDTO productDTO)
    {
        var response = new Response<bool>();
        try
        {
            var product = _mapper.Map<Product>(productDTO);
            response.Data = _productDomain.Insert(product);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Product Created Succesfully.";
                _logger.LogInformation("Product Created Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public Response<ProductDTO> Get(string ProductId)
    {
        var response = new Response<ProductDTO>();
        try
        {
            var product = _productDomain.Get(ProductId);
            response.Data = _mapper.Map<ProductDTO>(product);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Product Query Succesfully.";
                _logger.LogInformation("Product Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public Response<IEnumerable<ProductDTO>> GetAll()
    {
        var response = new Response<IEnumerable<ProductDTO>>();
        try
        {
            var products = _productDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<ProductDTO>>(products);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Product Query Succesfully.";
                _logger.LogInformation("Product Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public Response<bool> Update(ProductDTO productDTO)
    {
        var response = new Response<bool>();
        try
        {
            var product = _mapper.Map<Product>(productDTO);
            response.Data = _productDomain.Update(product);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Product Updated Succesfully";
                _logger.LogInformation("Product Updated Succesfully");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public Response<bool> Delete(string ProductId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _productDomain.Delete(ProductId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Product deleted Succesfully.";
                _logger.LogInformation("Product deleted Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }
    #endregion

    #region Asynchronous Methods
    public async Task<Response<bool>> InsertAsync(ProductDTO productDTO)
    {
        var response = new Response<bool>();
        try
        {
            var product = _mapper.Map<Product>(productDTO);
            response.Data = await _productDomain.InsertAsync(product);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Product Created Succesfully.";
                _logger.LogInformation("Product Created Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<ProductDTO>> GetAsync(string ProductId)
    {
        var response = new Response<ProductDTO>();
        try
        {
            var product = await _productDomain.GetAsync(ProductId);
            response.Data = _mapper.Map<ProductDTO>(product);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Product Query Succesfully.";
                _logger.LogInformation("Product Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<IEnumerable<ProductDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<ProductDTO>>();
        try
        {
            var products = await _productDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<ProductDTO>>(products);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Product Query Succesfully.";
                _logger.LogInformation("Product Query Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> UpdateAsync(ProductDTO productDTO)
    {
        var response = new Response<bool>();
        try
        {
            var product = _mapper.Map<Product>(productDTO);
            response.Data = await _productDomain.UpdateAsync(product);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Product Updated Succesfully";
                _logger.LogInformation("Product Updated Succesfully");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> DeleteAsync(string ProductId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _productDomain.DeleteAsync(ProductId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Product deleted Succesfully.";
                _logger.LogInformation("Product deleted Succesfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }
    #endregion

}
