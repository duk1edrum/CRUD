using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Service.Interfaces;

namespace Service.DTO
{
    public class UserDto
    {
        //Data transfer object модель для  передачи данных
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
