using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        /*[MinLength(6,ErrorMessage ="Your password needs to have at least 6 characters")]
        [MaxLength(30,ErrorMessage = "Your password exceeded the character limit of 30")]  */
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$",

ErrorMessage = "Your password does not meet the requirement of:Minimum six characters," +
            " at least one uppercase letter, one lowercase letter, one number and one special character ")]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage ="Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }



    }
}
