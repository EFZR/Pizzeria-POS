using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public EmployeeRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        #region Queries
        private readonly string INSERT = "INSERT INTO Employee (Emp_LocalId, Emp_FirstName, Emp_LastName, Emp_Phone) VALUES (@Emp_LocalId, @Emp_FirstName, @Emp_LastName, @Emp_Phone);";
        private readonly string SELECT = "SELECT * FROM Employee;";
        private readonly string SELECT_BY_ID = "SELECT * FROM Employee WHERE Emp_Id = @Emp_Id;";
        private readonly string UPDATE = "UPDATE Employee SET Emp_LocalId = @Emp_LocalId, Emp_FirstName = @Emp_FirstName, Emp_LastName = @Emp_LastName, Emp_Phone = @Emp_Phone WHERE Emp_Id = @Emp_Id;";
        private readonly string DELETE = "DELETE FROM Employee WHERE Emp_Id = @Emp_Id;";
        #endregion

        #region Synchronous Methods
        public bool Insert(Employee employee)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_LocalId", employee.Emp_LocalId);
            parameters.Add("Emp_FirstName", employee.Emp_FirstName);
            parameters.Add("Emp_LastName", employee.Emp_LastName);
            parameters.Add("Emp_Phone", employee.Emp_Phone);
            var result = connection.Execute(INSERT, parameters);
            return result > 0;
        }

        public IEnumerable<Employee> GetAll()
        {
            using var connection = _factoryConnection.GetConnection;
            var employees = connection.Query<Employee>(SELECT);
            return employees;
        }

        public Employee Get(string EmployeeId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_Id", EmployeeId);
            var employee = connection.QuerySingle<Employee>(SELECT_BY_ID, parameters);
            return employee;
        }

        public bool Update(Employee employee)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_Id", employee.Emp_Id);
            parameters.Add("Emp_LocalId", employee.Emp_LocalId);
            parameters.Add("Emp_FirstName", employee.Emp_FirstName);
            parameters.Add("Emp_LastName", employee.Emp_LastName);
            parameters.Add("Emp_Phone", employee.Emp_Phone);
            var result = connection.Execute(UPDATE, parameters);
            return result > 0;
        }

        public bool Delete(string EmployeeId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_Id", EmployeeId);
            var result = connection.Execute(DELETE, parameters);
            return result > 0;
        }
        #endregion

        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Employee employee)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_LocalId", employee.Emp_LocalId);
            parameters.Add("Emp_FirstName", employee.Emp_FirstName);
            parameters.Add("Emp_LastName", employee.Emp_LastName);
            parameters.Add("Emp_Phone", employee.Emp_Phone);
            var result = await connection.ExecuteAsync(INSERT, parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var connection = _factoryConnection.GetConnection;
            var employees = await connection.QueryAsync<Employee>(SELECT);
            return employees;
        }

        public async Task<Employee> GetAsync(string EmployeeId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_Id", EmployeeId);
            var employee = await connection.QuerySingleAsync<Employee>(SELECT_BY_ID, parameters);
            return employee;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_Id", employee.Emp_Id);
            parameters.Add("Emp_LocalId", employee.Emp_LocalId);
            parameters.Add("Emp_FirstName", employee.Emp_FirstName);
            parameters.Add("Emp_LastName", employee.Emp_LastName);
            parameters.Add("Emp_Phone", employee.Emp_Phone);
            var result = await connection.ExecuteAsync(UPDATE, parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string EmployeeId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Emp_Id", EmployeeId);
            var result = await connection.ExecuteAsync(DELETE, parameters);
            return result > 0;
        }
        #endregion
    }
}
