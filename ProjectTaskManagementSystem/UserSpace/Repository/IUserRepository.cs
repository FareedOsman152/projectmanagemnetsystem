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
    public bool GetUser(string username, string password, out User user);
    public IEnumerable<User> GetAllUsers();
}
