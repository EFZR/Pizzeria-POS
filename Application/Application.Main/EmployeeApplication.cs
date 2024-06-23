using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class EmployeeApplication : IEmployeeApplication
{
    private readonly IMapper _mapper;
    private readonly IEmployeeDomain _employeeDomain;
    private readonly IAppLogger<EmployeeApplication> _logger;

    public EmployeeApplication(IMapper mapper, IEmployeeDomain employeeDomain, IAppLogger<EmployeeApplication> logger)
    {
        _employeeDomain = employeeDomain;
        _mapper = mapper;
        _logger = logger;
    }

    #region Synchronous Methods
    public Response<bool> Insert(EmployeeDTO employeeDTO)
    {
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = _employeeDomain.Insert(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee Created Succesfully.";
                _logger.LogInformation("Employee Created Succesfully.");
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

    public Response<EmployeeDTO> Get(string EmployeeId)
    {
        var response = new Response<EmployeeDTO>();
        try
        {
            var employee = _employeeDomain.Get(EmployeeId);
            response.Data = _mapper.Map<EmployeeDTO>(employee);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employee Query Succesfully.";
                _logger.LogInformation("Employee Query Succesfully.");
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

    public Response<IEnumerable<EmployeeDTO>> GetAll()
    {
        var response = new Response<IEnumerable<EmployeeDTO>>();
        try
        {
            var employees = _employeeDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employee Query Succesfully.";
                _logger.LogInformation("Employee Query Succesfully.");
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

    public Response<bool> Update(EmployeeDTO employeeDTO)
    {
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = _employeeDomain.Update(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee Updated Succesfully";
                _logger.LogInformation("Employee Updated Succesfully");
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

    public Response<bool> Delete(string EmployeeId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _employeeDomain.Delete(EmployeeId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee deleted Succesfully.";
                _logger.LogInformation("Employee deleted Succesfully.");
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
    public async Task<Response<bool>> InsertAsync(EmployeeDTO employeeDTO)
    {
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = await _employeeDomain.InsertAsync(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee Created Succesfully.";
                _logger.LogInformation("Employee Created Succesfully.");
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

    public async Task<Response<EmployeeDTO>> GetAsync(string EmployeeId)
    {
        var response = new Response<EmployeeDTO>();
        try
        {
            var employee = await _employeeDomain.GetAsync(EmployeeId);
            response.Data = _mapper.Map<EmployeeDTO>(employee);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employee Query Succesfully.";
                _logger.LogInformation("Employee Query Succesfully.");
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

    public async Task<Response<IEnumerable<EmployeeDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<EmployeeDTO>>();
        try
        {
            var employees = await _employeeDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employee Query Succesfully.";
                _logger.LogInformation("Employee Query Succesfully.");
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

    public async Task<Response<bool>> UpdateAsync(EmployeeDTO employeeDTO)
    {
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = await _employeeDomain.UpdateAsync(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee Updated Succesfully";
                _logger.LogInformation("Employee Updated Succesfully");
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

    public async Task<Response<bool>> DeleteAsync(string EmployeeId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _employeeDomain.DeleteAsync(EmployeeId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee deleted Succesfully.";
                _logger.LogInformation("Employee deleted Succesfully.");
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
