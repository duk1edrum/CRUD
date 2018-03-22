using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Data.ViewModels
{
   public class UserViewModel
    {
        [Key]
        public int UserViewId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Both Password fields must match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

      
    }
}

