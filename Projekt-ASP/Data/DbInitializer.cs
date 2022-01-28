using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Projekt_ASP.Models;


namespace Projekt_ASP.Data
{
    public class DbInitializer
    {

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            Team teamEveryone = new Team()
            {
                Name = "Everyone"

            };

            Team teamFrontEnd = new Team()
            {
                Name = "Front end"

            };

            Team teamBackEnd = new Team()
            {
                Name = "Back end"

            };

            Team teamUX_UI = new Team()
            {
                Name = "UX UI design team"
            };

            context.Teams.Add(teamEveryone);
            context.Teams.Add(teamFrontEnd);
            context.Teams.Add(teamBackEnd);
            context.Teams.Add(teamUX_UI);

            ICollection<User> users = new List<User>()
            {
                new User(){User_ID="1",UserName = "JKowalski",Name="Jan",Surname="Kowalski",Email="JKowalski@gmail.com"},
                new User(){User_ID="2",UserName = "DLowery",Name="Danica",Surname="Lowery",Email="DLowery@gmail.com"},
                new User(){User_ID="3",UserName = "LSantana",Name="Lexie",Surname="Santana",Email="Santana@gmail.com"},
                new User(){User_ID="4",UserName = "IMontgomery",Name="Izabela",Surname="Montgomery",Email="Montgomery@gmail.com"},
                new User(){User_ID="5",UserName = "CMcgregor",Name="Cerys",Surname="Mcgregor",Email="Mcgregor@gmail.com"},
                new User(){User_ID="6",UserName = "HAsiyah",Name="Asiyah",Surname="Holder",Email="Holder@gmail.com"}

            };

            ICollection<Task> frontEndTasks = new List<Task>()
            {
                new Task(){Name = "Create git repository", CreatedBy="HAsiyah",finished=true},
                new Task(){Name = "Create git branches", CreatedBy="DLowery",finished=true},
                new Task(){Name = "Configure hosting", CreatedBy="HAsiyah",finished=true},
                new Task(){Name = "Create the test layout", CreatedBy="IMontgomery",finished=false},
                new Task(){Name = "Dom manipulation", CreatedBy="IMontgomery",finished=true},
                new Task(){Name = "Put colors into variables", CreatedBy="DLowery",finished=true},
                new Task(){Name = "Configure babel", CreatedBy="HAsiyah",finished=false},
                new Task(){Name = "fix login button", CreatedBy="IMontgomery",finished=true},
                new Task(){Name = "form not working on mobile", CreatedBy="DLowery",finished=true},
                new Task(){Name = "mail to function not working", CreatedBy="IMontgomery",finished=false}
            };

            ICollection<Task> everyoneTasks = new List<Task>()
            {
                new Task(){Name = "Meeting at 27.01 10:15", CreatedBy="CMcgregor",finished=true},
                new Task(){Name = "Technology discusion at 25.02 10:15", CreatedBy="LSantana",finished=true},
                new Task(){Name = "Fix the lights in room 5", CreatedBy="HAsiyah",finished=true},
                new Task(){Name = "Coffe machine broken", CreatedBy="JKowalski",finished=true},
                new Task(){Name = "Renew parking passes", CreatedBy="IMontgomery",finished=false},
                new Task(){Name = "Meet the applicants", CreatedBy="DLowery",finished=false},
                new Task(){Name = "Train the associates", CreatedBy="HAsiyah",finished=true},
                new Task(){Name = "Renew windows licence", CreatedBy="LSantana",finished=false},
                new Task(){Name = "Fix billing expences", CreatedBy="DLowery",finished=false},
                new Task(){Name = "Check your mail everyday", CreatedBy="CMcgregor",finished=false}
            };

            ICollection<Task> backEndTasks = new List<Task>()
            {
                new Task(){Name = "Fix user creation", CreatedBy="CMcgregor",finished=false},
                new Task(){Name = "Update database version", CreatedBy="LSantana",finished=false},
                new Task(){Name = "Debug mail function", CreatedBy="HAsiyah",finished=false},
                new Task(){Name = "Configure PHP server", CreatedBy="JKowalski",finished=false},
                new Task(){Name = "Configure cl flow", CreatedBy="IMontgomery",finished=false},
                new Task(){Name = "create a symphony project", CreatedBy="DLowery",finished=false},
                new Task(){Name = "create branches", CreatedBy="HAsiyah",finished=true},
                new Task(){Name = "Announce the project", CreatedBy="LSantana",finished=true},
                new Task(){Name = "Create api", CreatedBy="DLowery",finished=false},
                new Task(){Name = "Secure the api", CreatedBy="CMcgregor",finished=false}
            };

            ICollection<Task> UXUITasks = new List<Task>()
            {
                new Task(){Name = "Design navbar", CreatedBy="CMcgregor",finished=true},
                new Task(){Name = "Design homepage", CreatedBy="LSantana",finished=false},
                new Task(){Name = "Design contact form", CreatedBy="HAsiyah",finished=true},
                new Task(){Name = "Design footer", CreatedBy="JKowalski",finished=false},
                new Task(){Name = "Improve user experience on home page", CreatedBy="IMontgomery",finished=false},
                new Task(){Name = "Create grid on homepage", CreatedBy="DLowery",finished=true},
                new Task(){Name = "Mobile friendlines", CreatedBy="HAsiyah",finished=false},
                new Task(){Name = "Create animations", CreatedBy="LSantana",finished=false},
                new Task(){Name = "Get interns to test UI", CreatedBy="DLowery",finished=true},
                new Task(){Name = "Merge with frontend", CreatedBy="CMcgregor",finished=false}
            };

            foreach (Task task in frontEndTasks)
            {
                teamFrontEnd.Tasks.Add(task);
            }

            foreach (Task task in everyoneTasks)
            {
                teamEveryone.Tasks.Add(task);
            }

            foreach (Task task in backEndTasks)
            {
                teamBackEnd.Tasks.Add(task);
            }

            foreach (Task task in UXUITasks)
            {
                teamUX_UI.Tasks.Add(task);
            }




            foreach (User user in users)
            {
                user.Teams.Add(teamEveryone);
                if (int.Parse(user.User_ID)%2 == 0)
                {
                    user.Teams.Add(teamFrontEnd);
                    user.Teams.Add(teamUX_UI);
                }
                if (int.Parse(user.User_ID) % 3 == 0)
                {
                    user.Teams.Add(teamBackEnd);                    
                }

                context.Users.Add(user);              

            }
           
            context.SaveChanges();

            


        }





    }      
    
}
