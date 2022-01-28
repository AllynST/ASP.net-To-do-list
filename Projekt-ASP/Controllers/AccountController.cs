using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using projekt_asp.config;
using Projekt_ASP.Interfaces;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{    
    
    [Authorize]    
    [DisableBasic]
    public class AccountController : Controller
    {
        private ICRUDUserRepository repository;
        private ICRUDTeamRepository Trepository;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private ApplicationDbContext _context;

        public AccountController(ICRUDUserRepository repository, ICRUDTeamRepository Trepository, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            this.repository = repository;
            this.Trepository = Trepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public List<AuthenticationScheme> ExternalLogins { get; private set; }

        
        [AllowAnonymous]
        [HttpGet]        
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult YourAccount()
        {
            string LoggedName = User.Identity.Name;
            var user = this.repository.FindUserByName(LoggedName);
            return View(user);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult EditCredentials(string id)
        {
           
            return View("EditCredentials",this.repository.FindUserByID(id));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteUserAccount(string id)
        {
            IdentityUser IdentityUser = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(IdentityUser);

            
            this.repository.DeleteUser(id);

            await _signInManager.SignOutAsync();
              
           




            return Redirect("../../Account/Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ChangeCredentials(User user)
        {
            
            IdentityUser IUser = await _userManager.FindByIdAsync(user.User_ID);
            var EmailResult = await _userManager.ChangeEmailAsync(IUser, user.Email,null);
            var UserNameResult = await _userManager.SetUserNameAsync(IUser, user.UserName);
            
                repository.EditUserCredentials(user);
                
            

            return View("YourAccount",user);
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel LoginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await
               _userManager.FindByNameAsync(LoginModel.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user,
                    LoginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(LoginModel?.ReturnUrl ?? "App/index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
                    return View(LoginModel);
                }
                
                    
            }
            ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
            return View(LoginModel);

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<RedirectResult> Logout(string returnUrl ="/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                repository.AddUser(model);
                
                
                return View("../App/Index", Trepository.UserTeams(repository.FindUserByName(User.Identity.Name)));
            }
            else
            {
                return View("../ App/Register",model);
            }
            


            




        }

    }
}

