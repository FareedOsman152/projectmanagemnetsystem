using ProjectTaskManagementSystem.UserSpace.Repository;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Validator;

namespace ProjectTaskManagementSystem.UserSpace.Service;

class UserService : IUserService
{
    private readonly UserRepositoryFile _userRepository;
    private readonly UserValidator _userValidator;
    public UserService(UserRepositoryFile userRepository, UserValidator userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }
    public void AddNewUser(User user)
    {
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
    public User FindUser(string userName, string password)
    {
        return _userRepository.GetUser(userName, password);
    }
    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers().ToList();
    }
    public bool isValideUserInfo(string userName, string password)
    {
        return _userValidator.ValidateUsername(userName) && _userValidator.ValidatePassword(password);
    }
}
