
using Xunit;
using projekt_asp.Controllers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP_Tests;
using Projekt_ASP.Models;

namespace Rest_Api_Tester
{
    public class UserRestApiTest
    {        
       
        [Fact]
        public void AddUser()
        {
            UserMemoryRepository repository = new();
            repository.AddUser(new User()
            {
                UserName = "MariuszP",
                Name = "Mariusz",
                Surname = "Pudzianowski",
                Email = "MP@gmail.com"
            });
            repository.AddUser(new User()
            {
                UserName = "WSmish",
                Name = "Will",
                Surname = "Smith",
                Email = "WiliamKowalski@gmail.com"
            });

            Assert.Equal(2, repository.UserList().Count);

        }
        [Fact]
        public void FindById()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new User()
            {
                UserName = "MariuszP",
                Name = "Mariusz",
                Surname = "Pudzianowski",
                Email = "MP@gmail.com"
            });
            repository.AddUser(new User()
            {
                UserName = "WSmish",
                Name = "Will",
                Surname = "Smith",
                Email = "WiliamKowalski@gmail.com"
            });

            User user = new User()
            {
                UserName = "WSmish",
                Name = "Will",
                Surname = "Smith",
                Email = "WiliamKowalski@gmail.com"
            };



            Assert.Equal(repository.FindUser("1").Name, user.Name);
            Assert.Equal(repository.FindUser("1").UserName, user.UserName);
            Assert.Equal(repository.FindUser("1").Surname, user.Surname);
            Assert.Equal(repository.FindUser("1").Email, user.Email);
        }
        [Fact]
        public void EditUser()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new User()
            {
                UserName = "WSmish",
                Name = "Will",
                Surname = "Smith",
                Email = "WiliamKowalski@gmail.com"
            });

            User expected = new User()
            {
                UserName = "MariuszP",
                Name = "Mariusz",
                Surname = "Pudzianowski",
                Email = "MP@gmail.com"
            };

            repository.EditUser("0", expected);

            Assert.Equal(repository.FindUser("0").Name, expected.Name);
            Assert.Equal(repository.FindUser("0").UserName, expected.UserName);
            Assert.Equal(repository.FindUser("0").Surname, expected.Surname);
            Assert.Equal(repository.FindUser("0").Email, expected.Email);
        }
        [Fact]
        public void UserList()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new User()
            {
                UserName = "MariuszP",
                Name = "Mariusz",
                Surname = "Pudzianowski",
                Email = "MP@gmail.com"
            });
            repository.AddUser(new User()
            {
                UserName = "WSmish",
                Name = "Will",
                Surname = "Smith",
                Email = "WiliamKowalski@gmail.com"
            });

            Assert.Equal(2, repository.UserList().Count);
        }
        [Fact]
        public void DeleteUser()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new User()
            {
                UserName = "MariuszP",
                Name = "Mariusz",
                Surname = "Pudzianowski",
                Email = "MP@gmail.com"
            });
            repository.AddUser(new User()
            {
                UserName = "WSmish",
                Name = "Will",
                Surname = "Smith",
                Email = "WiliamKowalski@gmail.com"
            });

            Assert.Equal(2, repository.UserList().Count);

            repository.DeleteUser("0");

            Assert.Single(repository.UserList());
        }

    }

}
