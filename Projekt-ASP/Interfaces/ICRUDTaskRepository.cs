using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Interfaces
{
    public interface ICRUDTaskRepository
    {
        public IList<Models.Task> GetTasks();


    }
}
