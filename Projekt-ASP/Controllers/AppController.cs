using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekt_asp.config;
using Projekt_ASP.Interfaces;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
   
    [DisableBasic]    
    public class AppController : Controller
    {       
               
       
        private ICRUDTeamRepository Teamrepository;
        private ICRUDUserRepository Userrepository;

        public AppController(ICRUDTeamRepository Teamrepository, ICRUDUserRepository Userrepository)
        {
           
            this.Teamrepository = Teamrepository;
            this.Userrepository = Userrepository;
        }
        public IActionResult Index()
        {
                      
            return View(Teamrepository.UserTeams(Userrepository.FindUserByName(User.Identity.Name)));
        }
        
        public IActionResult TeamPage(int id)
        {
            
            var test = Teamrepository.GetTeamByID(id);
           
            return View("TeamPage",test);


        }
        public IActionResult AddTeamMemberPage(int id)
        {
            var test = Teamrepository.GetTeamByID(id);
            return View("../App/AddTeamMemberPage", test);
        }
        public IActionResult AddMember(Team team)
        {            
            Team teamData = Teamrepository.GetTeamByID(team.Team_ID);
            User user =  Userrepository.FindUserByName(team.Name);
            if(user == null)
            {
                ViewBag.Errors = "There is no user with that Username";
                return View("AddTeamMemberPage", Teamrepository.GetTeamByID(team.Team_ID));
            }
            else if (teamData.Members.Contains(user))
            {
                ViewBag.Errors = "That user is already in your team";
                return View("AddTeamMemberPage", Teamrepository.GetTeamByID(team.Team_ID));
            }
            else
            {
                Teamrepository.AddTeamMember(user, team.Team_ID);
                return View("TeamPage", teamData);
            }
        }
        public IActionResult ChangeTaskState(int id)
        {
            Teamrepository.ChangeTaskState(id);
            Models.Task task = Teamrepository.GetTaskById(id);
            Team team = Teamrepository.GetTeamByID(task.team.Team_ID);            
            return View("TeamPage",team );
        }
        public IActionResult DeleteTask(int id)
        {
            Models.Task task = Teamrepository.GetTaskById(id);
            
            Teamrepository.DeleteTaskById(id);
            Team team = Teamrepository.GetTeamByID(task.team.Team_ID);

            return View("TeamPage", team);
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult YourTeams()
        {
            var userTeams = Teamrepository.UserTeams(Userrepository.FindUserByName(User.Identity.Name));
            
            return View("../App/YourTeams",userTeams );
        }
        public IActionResult CreateTeam()
        {
            return View("../Team/CreateTeam");
        }
    }
}