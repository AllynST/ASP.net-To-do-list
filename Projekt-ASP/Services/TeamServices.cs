using Microsoft.EntityFrameworkCore.ChangeTracking;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_ASP.Interfaces
{
    public class TeamServices: ICRUDTeamRepository
    {

        private ApplicationDbContext _context;        

        public TeamServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Team GetTeamByID(int id)
        {
            Team test = _context.Teams.Find(id);
            _context.Teams
                .Where(b => b.Team_ID.Equals(id))
                .Include(T => T.Tasks)
                .FirstOrDefault();
            return test;
        }


        public IList<Models.Team> GetTeams()
        {

            return _context.Teams
            .Include(x => x.Members)
            .Include(T =>T.Tasks)
            .ToList();
        }
        public void CreateTeam(Team team)
        {            
            _context.Teams.Add(team);
            _context.SaveChanges();           

        }
        public void AddTeamMember(User user,int id)
        {
            Team before = GetTeamByID(id);

            before.Members.Add(user);           
            _context.SaveChanges();

        }
        public Models.Task GetTaskById(int id)
        {
            var response = _context.Tasks                
                .Include(c => c.team)
                .Where(t=>t.Task_ID.Equals(id))
                .FirstOrDefault();


            return response;
        } 
        public Models.Task ChangeTaskState(int id)
        {
            Models.Task task = GetTaskById(id);
            task.finished = !task.finished;
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return task;
        }
        public void DeleteTaskById(int id)
        {
            var task = GetTaskById(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        public List<Team> UserTeams(User user)
        {
            return _context.Teams.Where(T => T.Members.Contains(user))
                .Include(x=>x.Members)
                .Include(b =>b.Tasks)
                .ToList();
        }
       
       public void AddTask(Models.Task task,string user,Team team)
       {
            task.CreatedBy = user;
            task.team = team;
            _context.Tasks.Add(task);
            _context.SaveChanges();
       }
    }
}
