using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class CustomerApplication : ICustomerApplication
{
    private readonly IMapper _mapper;
    private readonly ICustomerDomain _customerDomain;
    private readonly IAppLogger<CustomerApplication> _logger;

    public CustomerApplication(IMapper mapper, ICustomerDomain customerDomain, IAppLogger<CustomerApplication> logger)
    {
        _customerDomain = customerDomain;
        _mapper = mapper;
        _logger = logger;
    }

    #region Synchronous Methods
    public Response<bool> Insert(CustomerDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = _customerDomain.Insert(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Customer Created Succesfully.";
                _logger.LogInformation("Customer Created Succesfully.");
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

    public Response<CustomerDTO> Get(string CustomerId)
    {
        var response = new Response<CustomerDTO>();
        try
        {
            var customer = _customerDomain.Get(CustomerId);
            response.Data = _mapper.Map<CustomerDTO>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Customer Query Succesfully.";
                _logger.LogInformation("Customer Query Succesfully.");
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

    public Response<IEnumerable<CustomerDTO>> GetAll()
    {
        var response = new Response<IEnumerable<CustomerDTO>>();
        try
        {
            var customers = _customerDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Customer Query Succesfully.";
                _logger.LogInformation("Customer Query Succesfully.");
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

    public Response<bool> Update(CustomerDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = _customerDomain.Update(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Customer Updated Succesfully";
                _logger.LogInformation("Customer Updated Succesfully");
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

    public Response<bool> Delete(string CustomerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _customerDomain.Delete(CustomerId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Customer deleted Succesfully.";
                _logger.LogInformation("Customer deleted Succesfully.");
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
    public async Task<Response<bool>> InsertAsync(CustomerDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = await _customerDomain.InsertAsync(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Customer Created Succesfully.";
                _logger.LogInformation("Customer Created Succesfully.");
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

    public async Task<Response<CustomerDTO>> GetAsync(string CustomerId)
    {
        var response = new Response<CustomerDTO>();
        try
        {
            var customer = await _customerDomain.GetAsync(CustomerId);
            response.Data = _mapper.Map<CustomerDTO>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Customer Query Succesfully.";
                _logger.LogInformation("Customer Query Succesfully.");
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

    public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<CustomerDTO>>();
        try
        {
            var customers = await _customerDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Customer Query Succesfully.";
                _logger.LogInformation("Customer Query Succesfully.");
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

    public async Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = await _customerDomain.UpdateAsync(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Customer Updated Succesfully";
                _logger.LogInformation("Customer Updated Succesfully");
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

    public async Task<Response<bool>> DeleteAsync(string CustomerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _customerDomain.DeleteAsync(CustomerId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Customer deleted Succesfully.";
                _logger.LogInformation("Customer deleted Succesfully.");
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
