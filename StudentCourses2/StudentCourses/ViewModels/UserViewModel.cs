using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentCourses.ViewModels
{
   public class UserViewModel
    {
       [Key]
       public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Both Password fields must match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

      
    }
}

