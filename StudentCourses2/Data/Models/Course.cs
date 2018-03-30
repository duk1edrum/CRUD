﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Room { get; set; }
        public bool Free { get; set; }
        

        public virtual ICollection<Student> Students{ get; set; }

    }
}
