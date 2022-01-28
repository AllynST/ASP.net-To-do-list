using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Projekt_ASP.Models
{
    public class User
    {
        public User()
        {
            Teams = new HashSet<Team>();
        }
        [Key]
        public string User_ID { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
       
        public string Email { get; set; }
        public ICollection<Team> Teams { get; set; }

        
    }
}
