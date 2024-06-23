using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;

namespace Domain.Core;

public class UserDomain : IUserDomain
{
    private readonly IUserRepository _userRepository;

    public UserDomain(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #region Synchronous Methods
    public bool Insert(User user)
    {
        return _userRepository.Insert(user);
    }
    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }
    public User Get(string UserId)
    {
        return _userRepository.Get(UserId);
    }
    public bool Update(User user)
    {
        return _userRepository.Update(user);
    }
    public bool Delete(string UserId)
    {
        return _userRepository.Delete(UserId);
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(User user)
    {
        return await _userRepository.InsertAsync(user);
    }
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }
    public async Task<User> GetAsync(string UserId)
    {
        return await _userRepository.GetAsync(UserId);
    }
    public async Task<bool> UpdateAsync(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }
    public async Task<bool> DeleteAsync(string UserId)
    {
        return await _userRepository.DeleteAsync(UserId);
    }
    #endregion
}