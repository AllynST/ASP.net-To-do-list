using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Data
{
    public static class IdentitySeedData
    {       
        private const string Password = "zaq1@WSX";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<IdentityUser>)scope

               .ServiceProvider.GetService(typeof(UserManager<IdentityUser>));

                IEnumerable<IdentityUser> users = new List<IdentityUser>()
                {                  
            
                    new IdentityUser(){Id="1",UserName = "JKowalski",Email="JKowalski@gmail"},
                    new IdentityUser(){Id="2",UserName = "DLowery",Email="DLowery@gmail"},
                    new IdentityUser(){Id="3",UserName = "LSantana",Email="Santana@gmail"},
                    new IdentityUser(){Id="4",UserName = "IMontgomery",Email="Montgomery@gmail"},
                    new IdentityUser(){Id="5",UserName = "CMcgregor",Email="Mcgregor@gmail"},
                    new IdentityUser(){Id="6",UserName = "HAsiyah",Email="Holder@gmail"}

                };
                IdentityUser user = await
                userManager.FindByIdAsync("1");
                if (user == null)
                {
                    foreach (IdentityUser Iuser in users)
                    {
                        await userManager.CreateAsync(Iuser, Password);
                    }
                }



                                  
                    
                
            }
        }
    }
}
