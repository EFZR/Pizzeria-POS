using Domain.Entity;

namespace Domain.Interface;

public interface IUserDomain
{
    Task<bool> CreateAccount(User user);
    Task<User> Authenticate(string email, string password);
}