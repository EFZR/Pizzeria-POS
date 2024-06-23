using Domain.Entity;

namespace Domain.Interface;

public interface IEmployeeDomain
{
    #region Synchronous Methods
    bool Insert(Employee employee);
    bool Update(Employee employee);
    bool Delete(string EmployeeId);
    Employee Get(string EmployeeId);
    IEnumerable<Employee> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(Employee employee);
    Task<bool> UpdateAsync(Employee employee);
    Task<bool> DeleteAsync(string EmployeeId);
    Task<Employee> GetAsync(string EmployeeId);
    Task<IEnumerable<Employee>> GetAllAsync();
    #endregion
}