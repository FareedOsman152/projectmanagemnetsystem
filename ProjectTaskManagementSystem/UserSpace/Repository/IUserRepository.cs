using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.UserSpace.Repository;

internal interface IUserRepository
{
    public void AddNewUser(User user);
    public void DeleteUser(User user);
    public void UpdateUser(User user);
    public User GetUser(string username, string password);
    public IEnumerable<User> GetAllUsers();
}
