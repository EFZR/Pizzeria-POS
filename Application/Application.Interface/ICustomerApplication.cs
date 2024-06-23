using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface ICustomerApplication
{
    #region Synchronous Methods
    Response<bool> Insert(CustomerDTO customerDTO);
    Response<bool> Update(CustomerDTO customerDTO);
    Response<bool> Delete(string CustomerId);
    Response<CustomerDTO> Get(string CustomerId);
    Response<IEnumerable<CustomerDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(CustomerDTO customerDTO);
    Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO);
    Task<Response<bool>> DeleteAsync(string CustomerId);
    Task<Response<CustomerDTO>> GetAsync(string CustomerId);
    Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
    #endregion
}
