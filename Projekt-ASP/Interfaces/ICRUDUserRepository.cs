using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{

    public interface ICRUDUserRepository
    {
        IList<User> GetUser();

        System.Threading.Tasks.Task AddUser(RegisterModel model);
        List<Team> UserTeams(User user);
        void DeleteUser(string id);
        User FindUserByID(string id);

        User EditUserCredentials(User user);
        
        User FindUserByName(string name);
    }
}
