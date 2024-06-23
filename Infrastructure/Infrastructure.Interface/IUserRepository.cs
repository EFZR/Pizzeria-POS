using Domain.Entity;

namespace Infrastructure.Interface;

public interface IUserRepository
{
    #region Synchronous Methods
    bool Insert(User user);
    bool Update(User user);
    bool Delete(string UserId);
    User Get(string UserId);
    IEnumerable<User> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(string UserId);
    Task<User> GetAsync(string UserId);
    Task<IEnumerable<User>> GetAllAsync();
    #endregion
}