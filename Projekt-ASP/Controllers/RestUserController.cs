using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using projekt_asp.config;
using Projekt_ASP.Models;
using ServiceStack.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Projekt_ASP.Models.Task;


namespace projekt_asp.Controllers
{
    [Route("api/task")]
    [ApiController]
    [AllowAnonymous]
    public class RestUser_Controller : ControllerBase
    {       
        private ICRUDUserRepository _userRepository;

        public RestUser_Controller(ICRUDUserRepository UserRepository)
        {            
            _userRepository = UserRepository;
        }

        [DisableBasic]
        [HttpGet]
        public List<User> UserList()
        {
            return (List<User>)_userRepository.GetUser();            
            //TODO RETURN TASK LIST BASED ON USER
        }


        [HttpDelete]
        [Route("{id}")]
        public User DeleteUser(string id)
        {
            User user  = _userRepository.FindUserByID(id);
            _userRepository.DeleteUser(id);
            return user;
        }


        [DisableBasic]
        [HttpGet]
        [Route("{id}")]
        public User FindUser(string id)
        {          
            return _userRepository.FindUserByID(id);
        }

        [DisableBasic]
        [HttpPost]
        public RegisterModel AddUser([FromBody] RegisterModel user)
        {

            try
            {
                _userRepository.AddUser(user);
                return user;
            }
            catch
            {
                throw new HttpException(400, "Bad Request");                
            }
            
            
            
        }

        [HttpPut("{id}")]
        public ActionResult<User> EditUser(string id, [FromBody] User user)
        {
            try
            {
                User Before = _userRepository.EditUserCredentials(user);
                return Before;
            }
            catch
            {
                throw new HttpException(400, "Bad Request");
            }
            
        }
    }
}