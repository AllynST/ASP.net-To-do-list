using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Task
    {
        [Key]
        public int Task_ID { get; set; }

        public string Name { get; set; }

        public bool finished { get; set; }
        public Team team { get; set; }
        public string CreatedBy { get; set; }

    }
}
