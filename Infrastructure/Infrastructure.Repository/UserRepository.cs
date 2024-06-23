using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public UserRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        #region Queries
        private readonly string INSERT = "INSERT INTO User (User_EmpId, User_Username, User_Email, User_Password, User_PasswordSalt, User_TokenSalt) VALUES (@User_EmpId, @User_Username, @User_Email, @User_Password, @User_PasswordSalt, @User_TokenSalt);";
        private readonly string SELECT = "SELECT * FROM User;";
        private readonly string SELECT_BY_ID = "SELECT * FROM User WHERE User_Id = @User_Id;";
        private readonly string UPDATE = "UPDATE User SET User_EmpId = @User_EmpId, User_Username = @User_Username, User_Email = @User_Email, User_Password = @User_Password, User_PasswordSalt = @User_PasswordSalt, User_TokenSalt = @User_TokenSalt WHERE User_Id = @User_Id;";
        private readonly string DELETE = "DELETE FROM User WHERE User_Id = @User_Id;";
        #endregion

        #region Synchronous Methods
        public bool Insert(User user)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_EmpId", user.User_EmpId);
            parameters.Add("User_Username", user.User_Username);
            parameters.Add("User_Email", user.User_Email);
            parameters.Add("User_Password", user.User_Password);
            parameters.Add("User_PasswordSalt", user.User_PasswordSalt);
            parameters.Add("User_TokenSalt", user.User_TokenSalt);
            var result = connection.Execute(INSERT, parameters);
            return result > 0;
        }

        public IEnumerable<User> GetAll()
        {
            using var connection = _factoryConnection.GetConnection;
            var users = connection.Query<User>(SELECT);
            return users;
        }

        public User Get(string UserId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_Id", UserId);
            var user = connection.QuerySingle<User>(SELECT_BY_ID, parameters);
            return user;
        }

        public bool Update(User user)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_Id", user.User_Id);
            parameters.Add("User_EmpId", user.User_EmpId);
            parameters.Add("User_Username", user.User_Username);
            parameters.Add("User_Email", user.User_Email);
            parameters.Add("User_Password", user.User_Password);
            parameters.Add("User_PasswordSalt", user.User_PasswordSalt);
            parameters.Add("User_TokenSalt", user.User_TokenSalt);
            var result = connection.Execute(UPDATE, parameters);
            return result > 0;
        }

        public bool Delete(string UserId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_Id", UserId);
            var result = connection.Execute(DELETE, parameters);
            return result > 0;
        }
        #endregion

        #region Asynchronous Methods
        public async Task<bool> InsertAsync(User user)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_EmpId", user.User_EmpId);
            parameters.Add("User_Username", user.User_Username);
            parameters.Add("User_Email", user.User_Email);
            parameters.Add("User_Password", user.User_Password);
            parameters.Add("User_PasswordSalt", user.User_PasswordSalt);
            parameters.Add("User_TokenSalt", user.User_TokenSalt);
            var result = await connection.ExecuteAsync(INSERT, parameters);
            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var connection = _factoryConnection.GetConnection;
            var users = await connection.QueryAsync<User>(SELECT);
            return users;
        }

        public async Task<User> GetAsync(string UserId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_Id", UserId);
            var user = await connection.QuerySingleAsync<User>(SELECT_BY_ID, parameters);
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_Id", user.User_Id);
            parameters.Add("User_EmpId", user.User_EmpId);
            parameters.Add("User_Username", user.User_Username);
            parameters.Add("User_Email", user.User_Email);
            parameters.Add("User_Password", user.User_Password);
            parameters.Add("User_PasswordSalt", user.User_PasswordSalt);
            parameters.Add("User_TokenSalt", user.User_TokenSalt);
            var result = await connection.ExecuteAsync(UPDATE, parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string UserId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("User_Id", UserId);
            var result = await connection.ExecuteAsync(DELETE, parameters);
            return result > 0;
        }
        #endregion
    }
}
