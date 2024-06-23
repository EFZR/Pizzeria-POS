using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class CountryApplication : ICountryApplication
{
    private readonly IMapper _mapper;
    private readonly ICountryDomain _countryDomain;
    private readonly IAppLogger<CountryApplication> _logger;

    public CountryApplication(IMapper mapper, ICountryDomain countryDomain, IAppLogger<CountryApplication> logger)
    {
        _countryDomain = countryDomain;
        _mapper = mapper;
        _logger = logger;
    }

    #region Synchronous Methods
    public Response<bool> Insert(CountryDTO countryDTO)
    {
        var response = new Response<bool>();
        try
        {
            var country = _mapper.Map<Country>(countryDTO);
            response.Data = _countryDomain.Insert(country);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Country Created Succesfully.";
                _logger.LogInformation("Country Created Succesfully.");
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

    public Response<CountryDTO> Get(string CountryId)
    {
        var response = new Response<CountryDTO>();
        try
        {
            var country = _countryDomain.Get(CountryId);
            response.Data = _mapper.Map<CountryDTO>(country);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Country Query Succesfully.";
                _logger.LogInformation("Country Query Succesfully.");
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

    public Response<IEnumerable<CountryDTO>> GetAll()
    {
        var response = new Response<IEnumerable<CountryDTO>>();
        try
        {
            var countries = _countryDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<CountryDTO>>(countries);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Country Query Succesfully.";
                _logger.LogInformation("Country Query Succesfully.");
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

    public Response<bool> Update(CountryDTO countryDTO)
    {
        var response = new Response<bool>();
        try
        {
            var country = _mapper.Map<Country>(countryDTO);
            response.Data = _countryDomain.Update(country);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Country Updated Succesfully";
                _logger.LogInformation("Country Updated Succesfully");
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

    public Response<bool> Delete(string CountryId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _countryDomain.Delete(CountryId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Country deleted Succesfully.";
                _logger.LogInformation("Country deleted Succesfully.");
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
    public async Task<Response<bool>> InsertAsync(CountryDTO countryDTO)
    {
        var response = new Response<bool>();
        try
        {
            var country = _mapper.Map<Country>(countryDTO);
            response.Data = await _countryDomain.InsertAsync(country);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Country Created Succesfully.";
                _logger.LogInformation("Country Created Succesfully.");
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

    public async Task<Response<CountryDTO>> GetAsync(string CountryId)
    {
        var response = new Response<CountryDTO>();
        try
        {
            var country = await _countryDomain.GetAsync(CountryId);
            response.Data = _mapper.Map<CountryDTO>(country);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Country Query Succesfully.";
                _logger.LogInformation("Country Query Succesfully.");
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

    public async Task<Response<IEnumerable<CountryDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<CountryDTO>>();
        try
        {
            var countries = await _countryDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<CountryDTO>>(countries);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Country Query Succesfully.";
                _logger.LogInformation("Country Query Succesfully.");
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

    public async Task<Response<bool>> UpdateAsync(CountryDTO countryDTO)
    {
        var response = new Response<bool>();
        try
        {
            var country = _mapper.Map<Country>(countryDTO);
            response.Data = await _countryDomain.UpdateAsync(country);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Country Updated Succesfully";
                _logger.LogInformation("Country Updated Succesfully");
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

    public async Task<Response<bool>> DeleteAsync(string CountryId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _countryDomain.DeleteAsync(CountryId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Country deleted Succesfully.";
                _logger.LogInformation("Country deleted Succesfully.");
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
