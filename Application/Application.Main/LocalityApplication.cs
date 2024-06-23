using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class LocalityApplication : ILocalityApplication
{
    private readonly IMapper _mapper;
    private readonly ILocalityDomain _localityDomain;
    private readonly IAppLogger<LocalityApplication> _logger;

    public LocalityApplication(IMapper mapper, ILocalityDomain localityDomain, IAppLogger<LocalityApplication> logger)
    {
        _localityDomain = localityDomain;
        _mapper = mapper;
        _logger = logger;
    }

    #region Synchronous
    public Response<bool> Insert(LocalityDTO localityDTO)
    {
        var response = new Response<bool>();
        try
        {
            var locality = _mapper.Map<Locality>(localityDTO);
            response.Data = _localityDomain.Insert(locality);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Locality Created Succesfully.";
                _logger.LogInformation("Locality Created Succesfully.");
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

    public Response<LocalityDTO> Get(string LocalityId)
    {
        var response = new Response<LocalityDTO>();
        try
        {
            var locality = _localityDomain.Get(LocalityId);
            response.Data = _mapper.Map<LocalityDTO>(locality);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Locality Query Succesfully.";
                _logger.LogInformation("Locality Query Succesfully.");
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

    public Response<IEnumerable<LocalityDTO>> GetAll()
    {
        var response = new Response<IEnumerable<LocalityDTO>>();
        try
        {
            var localities = _localityDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<LocalityDTO>>(localities);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Locality Query Succesfully.";
                _logger.LogInformation("Locality Query Succesfully.");
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

    public Response<bool> Update(LocalityDTO localityDTO)
    {
        var response = new Response<bool>();
        try
        {
            var locality = _mapper.Map<Locality>(localityDTO);
            response.Data = _localityDomain.Update(locality);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Locality Updated Succesfully";
                _logger.LogInformation("Locality Updated Succesfully");
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

    public Response<bool> Delete(string LocalityId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _localityDomain.Delete(LocalityId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Locality deleted Succesfully.";
                _logger.LogInformation("Locality deleted Succesfully.");
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

    #region Asynchronous
    public async Task<Response<bool>> InsertAsync(LocalityDTO localityDTO)
    {
        var response = new Response<bool>();
        try
        {
            var locality = _mapper.Map<Locality>(localityDTO);
            response.Data = await _localityDomain.InsertAsync(locality);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Locality Created Succesfully.";
                _logger.LogInformation("Locality Created Succesfully.");
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

    public async Task<Response<LocalityDTO>> GetAsync(string LocalityId)
    {
        var response = new Response<LocalityDTO>();
        try
        {
            var locality = await _localityDomain.GetAsync(LocalityId);
            response.Data = _mapper.Map<LocalityDTO>(locality);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Locality Query Succesfully.";
                _logger.LogInformation("Locality Query Succesfully.");
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

    public async Task<Response<IEnumerable<LocalityDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<LocalityDTO>>();
        try
        {
            var localities = await _localityDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<LocalityDTO>>(localities);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Locality Query Succesfully.";
                _logger.LogInformation("Locality Query Succesfully.");
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

    public async Task<Response<bool>> UpdateAsync(LocalityDTO localityDTO)
    {
        var response = new Response<bool>();
        try
        {
            var locality = _mapper.Map<Locality>(localityDTO);
            response.Data = await _localityDomain.UpdateAsync(locality);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Locality Updated Succesfully";
                _logger.LogInformation("Locality Updated Succesfully");
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

    public async Task<Response<bool>> DeleteAsync(string LocalityId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _localityDomain.DeleteAsync(LocalityId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Locality deleted Succesfully.";
                _logger.LogInformation("Locality deleted Succesfully.");
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
