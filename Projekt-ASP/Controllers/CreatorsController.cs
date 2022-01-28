using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_ASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Projekt_ASP.Interfaces;
using projekt_asp.config;

namespace Projekt_ASP.Controllers
{
    [DisableBasic]
    public class CreatorsController : Controller
    {
        private ICRUDUserRepository Userrepository;
        private ICRUDTeamRepository Teamrepository;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public CreatorsController(ICRUDUserRepository Userrepository, ICRUDTeamRepository Teamrepository, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this.Teamrepository = Teamrepository;
            this.Userrepository = Userrepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }




        public IActionResult Index()
        {
            return View();
        }        
        public IActionResult CreateTeamPage()
        {
            return View("CreateTeamPage");
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        public IActionResult UserList()
        {
            return View("UserList", Userrepository.GetUser());
        }
        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {        
            User user = Userrepository.FindUserByName(_signInManager.Context.User.Identity.Name);
            Teamrepository.CreateTeam(team);
            Teamrepository.AddTeamMember(user, team.Team_ID);

            return View("../App/YourTeams", Teamrepository.UserTeams(user));
        }
        [HttpGet]
        public IActionResult AddTaskPage(int id)
        {
            HttpContext.Session.SetInt32("CurrentTeam",id);
            ViewData["Team"] = Teamrepository.GetTeamByID(id);
            ViewData["User"] = Userrepository.FindUserByName(_signInManager.Context.User.Identity.Name);
            return View("AddTask");
        }
        [HttpPost]
        public IActionResult AddTask(Models.Task task)
        {
            User user = Userrepository.FindUserByName(_signInManager.Context.User.Identity.Name);
            int test = (int)HttpContext.Session.GetInt32("CurrentTeam");
            Team team = Teamrepository.GetTeamByID(test);
            Teamrepository.AddTask(task,user.Name,team);
            return View("../App/YourTeams", Teamrepository.UserTeams(user));
        }
       

    }
}

