using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {

        public int  UserId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The Name maximum 20 symbols")]
        public string Name { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "The Last Name maximum 20 symbols")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
