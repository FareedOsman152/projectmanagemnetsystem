﻿using System;
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
    public User GetUserById(string Id);
    public User GetUserByUsername(string username);
    public IEnumerable<User> GetAllUsers();
}
