﻿using System;
using System.Collections.Generic;
using System.Text;

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