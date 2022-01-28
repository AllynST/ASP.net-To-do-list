using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Team
    {
        public Team()
        {
            Members = new HashSet<User>();
            Tasks = new HashSet<Task>();
        }
        [Key]
        public int Team_ID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
        
        public ICollection<User> Members { get; set; }       



    }

}
