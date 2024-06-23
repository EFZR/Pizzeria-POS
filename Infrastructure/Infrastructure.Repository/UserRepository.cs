using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IFactoryConnection _factoryConnection;
    public UserRepository(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }

    #region Queries
    private readonly string SELECT_USER_BY_EMAIL = "SELECT * FROM User WHERE User_Email = @User_Email;";
    private readonly string CREATE_ACCOUNT = "INSERT INTO User (User_EmpId, User_Username, User_Email, User_Password, User_PasswordSalt, User_TokenSalt) VALUES (@User_EmpId, @User_Username, @User_Email, @User_Password, @User_PasswordSalt, @User_TokenSalt);";
    #endregion

    public async Task<bool> CreateAccount(User user)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters();
        parameters.Add("User_EmpId", user.User_EmpId);
        parameters.Add("User_Username", user.User_Username);
        parameters.Add("User_Email", user.User_Email);
        parameters.Add("User_Password", user.User_Password);
        parameters.Add("User_PasswordSalt", user.User_PasswordSalt);
        parameters.Add("User_TokenSalt", user.User_TokenSalt);
        var result = await connection.ExecuteAsync(CREATE_ACCOUNT, parameters);
        return result > 0;
    }

    public async Task<User> Authenticate(string email)
    {
        using var connection = _factoryConnection.GetConnection;
        var parameters = new DynamicParameters();
        parameters.Add("User_Email", email);
        var user = await connection.QuerySingleAsync<User>(SELECT_USER_BY_EMAIL, parameters);
        return user;
    }
}

