using ProjectTaskManagementSystem.UserSpace.Repository;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

namespace ProjectTaskManagementSystem.UserSpace.Service;

class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _userValidator;
    public UserService(UserRepositoryFile userRepository, IUserValidator userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }
    public void AddNewUser(User user)
    {
        if(!isUserNameIsAvailable(user.UserName))
            throw new Exception("User name is not available");
        _userRepository.AddNewUser(user);
    }
    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
    }
    public void DeleteUser(User user)
    {
        _userRepository.DeleteUser(user);
    }
    public User FindUser(string userName)
    {
        return _userRepository.GetUser(userName);
    }
    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers().ToList();
    }
    public bool isValideUserInfo(string userName, string password)
    {
        return _userValidator.ValidateUsername(userName) && _userValidator.ValidatePassword(password);
    }
    public bool isUserNameIsAvailable(string userName)
    {
        return _userRepository.GetAllUsers().Any(user => user.UserName == userName);
    }
}
