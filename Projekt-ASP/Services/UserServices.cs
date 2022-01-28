using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Services
{
    public class UserServices:ICRUDUserRepository
    {

        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;


        public UserServices(ApplicationDbContext context, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _context = context;           
            _userManager = userManager;
            _signInManager = signInManager;
           
        }

        

        public User FindUserByID(string id)
        {            
            return  _context.Users.Find(id);
        }
        public User FindUserByName(string name)
        {
            try
            {
                User user = _context.Users.Where(user => user.UserName.Equals(name)).First();
                return user;
            }
            catch(Exception)
            {
                return null;
            }      
          
        }
        public User EditUserCredentials(User user)
        {
            User before = _context.Users.Find(user.User_ID);
            before.UserName = user.UserName;
            before.Name = user.Name;
            before.Surname = user.Surname;
            before.Email = user.Email;
            EntityEntry<User> entityEntry = _context.Users.Update(before);
            _context.SaveChanges();
            return entityEntry.Entity;

        }
               

        public IList<User> GetUser()
        {
            return _context.Users
                
                
                .ToList();
        }
        public void AddUser(RegisterModel model)
        {
            IdentityUser Identityuser = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result =   _userManager.CreateAsync(Identityuser, model.Password);

                User user = new User
                {
                    User_ID = Identityuser.Id,
                    UserName = model.UserName,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email

                };
                _context.Users.Add(user);
                _context.SaveChanges();
               
                     
        }
        public List<Team> UserTeams(User user)
        {
            return _context.Users.Find(user.User_ID).Teams.ToList();
        }
        public  void DeleteUser(string id)
        {

             _context.Users.Remove(FindUserByID(id));
             _context.SaveChanges();           
        }    


    }
}
