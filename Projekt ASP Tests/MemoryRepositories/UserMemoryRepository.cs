using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_ASP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Projekt_ASP_Tests
{
    class UserMemoryRepository : IUserApi
    {
        private Dictionary<string, User> _Users = new();
        private string Iterator = "0";
        public UserMemoryRepository()
        {

        }

        public User AddUser([FromBody] User user)
        {
            _Users.Add(Iterator, user);
            Iterator = (int.Parse(Iterator) + 1).ToString();
            return user;
        }

        public void DeleteUser(string id)
        {
            _Users.Remove(id);

        }

        public void EditUser(string id, [FromBody] User user)
        {
            _Users[id].UserName = user.UserName;
            _Users[id].Name = user.Name;
            _Users[id].Surname = user.Surname;
            _Users[id].Email = user.Email;         
        }
        public List<User> UserList()
        {
            return _Users.Values.ToList();
        }
        public User FindUser(string id)
        {
            return _Users[id];
        }

    }    
}   