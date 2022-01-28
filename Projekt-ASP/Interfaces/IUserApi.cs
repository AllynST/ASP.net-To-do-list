using Microsoft.AspNetCore.Mvc;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Interfaces
{
    public interface IUserApi
    {

        public List<User> UserList();
        public void DeleteUser(string id);
        public User FindUser(string id);
        public User AddUser([FromBody] User user);
        public void EditUser(string id, [FromBody] User user);
       
    }
}
