using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IEmployeeApplication
{
    #region Synchronous Methods
    Response<bool> Insert(EmployeeDTO employeeDTO);
    Response<bool> Update(EmployeeDTO employeeDTO);
    Response<bool> Delete(string EmployeeId);
    Response<EmployeeDTO> Get(string EmployeeId);
    Response<IEnumerable<EmployeeDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(EmployeeDTO employeeDTO);
    Task<Response<bool>> UpdateAsync(EmployeeDTO employeeDTO);
    Task<Response<bool>> DeleteAsync(string EmployeeId);
    Task<Response<EmployeeDTO>> GetAsync(string EmployeeId);
    Task<Response<IEnumerable<EmployeeDTO>>> GetAllAsync();
    #endregion
}
