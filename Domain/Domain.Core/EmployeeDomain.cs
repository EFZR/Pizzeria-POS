using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;

namespace Domain.Core;

public class EmployeeDomain : IEmployeeDomain
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeDomain(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    #region Synchronous Methods
    public bool Insert(Employee employee)
    {
        return _employeeRepository.Insert(employee);
    }
    public IEnumerable<Employee> GetAll()
    {
        return _employeeRepository.GetAll();
    }
    public Employee Get(string EmployeeId)
    {
        return _employeeRepository.Get(EmployeeId);
    }
    public bool Update(Employee employee)
    {
        return _employeeRepository.Update(employee);
    }
    public bool Delete(string EmployeeId)
    {
        return _employeeRepository.Delete(EmployeeId);
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Employee employee)
    {
        return await _employeeRepository.InsertAsync(employee);
    }
    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }
    public async Task<Employee> GetAsync(string EmployeeId)
    {
        return await _employeeRepository.GetAsync(EmployeeId);
    }
    public async Task<bool> UpdateAsync(Employee employee)
    {
        return await _employeeRepository.UpdateAsync(employee);
    }
    public async Task<bool> DeleteAsync(string EmployeeId)
    {
        return await _employeeRepository.DeleteAsync(EmployeeId);
    }
    #endregion
}