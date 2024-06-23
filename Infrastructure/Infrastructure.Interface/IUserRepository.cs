using Domain.Entity;

namespace Infrastructure.Interface;

public interface IUserRepository
{
    Task<bool> CreateAccount(User user);
    Task<User> Authenticate(string email);
}