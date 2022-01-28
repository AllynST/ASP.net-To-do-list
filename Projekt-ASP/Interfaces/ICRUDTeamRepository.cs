using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Interfaces
{
    public interface ICRUDTeamRepository
    {
        //TEST FUNCTION
        public IList<Models.Team> GetTeams();
        //
        void CreateTeam(Models.Team team);
        void AddTeamMember(User user, int id);
        Team GetTeamByID(int id);
        Models.Task ChangeTaskState(int id);
        void DeleteTaskById(int id);
        Models.Task GetTaskById(int id);
        List<Team> UserTeams(User user);
        void AddTask(Models.Task task,string user,Team team);
    }
}
