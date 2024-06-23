using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class ProvinceApplication : IProvinceApplication
{
    private readonly IMapper _mapper;
    private readonly IProvinceDomain _provinceDomain;
    private readonly IAppLogger<ProvinceApplication> _logger;

    public ProvinceApplication(IMapper mapper, IProvinceDomain provinceDomain, IAppLogger<ProvinceApplication> logger)
    {
        _provinceDomain = provinceDomain;
        _mapper = mapper;
        _logger = logger;
    }

    #region Synchronous Methods
    public Response<bool> Insert(ProvinceDTO provinceDTO)
    {
        var response = new Response<bool>();
        try
        {
            var province = _mapper.Map<Province>(provinceDTO);
            response.Data = _provinceDomain.Insert(province);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Province Created Succesfully.";
                _logger.LogInformation("Province Created Succesfully.");
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

    public Response<ProvinceDTO> Get(string ProvinceId)
    {
        var response = new Response<ProvinceDTO>();
        try
        {
            var province = _provinceDomain.Get(ProvinceId);
            response.Data = _mapper.Map<ProvinceDTO>(province);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Province Query Succesfully.";
                _logger.LogInformation("Province Query Succesfully.");
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

    public Response<IEnumerable<ProvinceDTO>> GetAll()
    {
        var response = new Response<IEnumerable<ProvinceDTO>>();
        try
        {
            var provinces = _provinceDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<ProvinceDTO>>(provinces);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Province Query Succesfully.";
                _logger.LogInformation("Province Query Succesfully.");
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

    public Response<bool> Update(ProvinceDTO provinceDTO)
    {
        var response = new Response<bool>();
        try
        {
            var province = _mapper.Map<Province>(provinceDTO);
            response.Data = _provinceDomain.Update(province);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Province Updated Succesfully";
                _logger.LogInformation("Province Updated Succesfully");
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

    public Response<bool> Delete(string ProvinceId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _provinceDomain.Delete(ProvinceId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Province deleted Succesfully.";
                _logger.LogInformation("Province deleted Succesfully.");
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
    public async Task<Response<bool>> InsertAsync(ProvinceDTO provinceDTO)
    {
        var response = new Response<bool>();
        try
        {
            var province = _mapper.Map<Province>(provinceDTO);
            response.Data = await _provinceDomain.InsertAsync(province);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Province Created Succesfully.";
                _logger.LogInformation("Province Created Succesfully.");
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

    public async Task<Response<ProvinceDTO>> GetAsync(string ProvinceId)
    {
        var response = new Response<ProvinceDTO>();
        try
        {
            var province = await _provinceDomain.GetAsync(ProvinceId);
            response.Data = _mapper.Map<ProvinceDTO>(province);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Province Query Succesfully.";
                _logger.LogInformation("Province Query Succesfully.");
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

    public async Task<Response<IEnumerable<ProvinceDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<ProvinceDTO>>();
        try
        {
            var provinces = await _provinceDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<ProvinceDTO>>(provinces);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Province Query Succesfully.";
                _logger.LogInformation("Province Query Succesfully.");
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

    public async Task<Response<bool>> UpdateAsync(ProvinceDTO provinceDTO)
    {
        var response = new Response<bool>();
        try
        {
            var province = _mapper.Map<Province>(provinceDTO);
            response.Data = await _provinceDomain.UpdateAsync(province);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Province Updated Succesfully";
                _logger.LogInformation("Province Updated Succesfully");
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

    public async Task<Response<bool>> DeleteAsync(string ProvinceId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _provinceDomain.DeleteAsync(ProvinceId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Province deleted Succesfully.";
                _logger.LogInformation("Province deleted Succesfully.");
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
