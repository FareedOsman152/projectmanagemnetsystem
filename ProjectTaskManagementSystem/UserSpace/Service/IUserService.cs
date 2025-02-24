using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.UserSpace.Service;
interface IUserService
{
    void AddNewUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    User FindUser(string userName);
    List<User> GetAllUsers();
    bool isUserNameIsAvailable(string userName);
    bool isValideUserInfo(string userName, string password);
}
