﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentCourses.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Room { get; set; }
        public bool Free { get; set; }

        public List<CheckBoxViewModel> Students  { get; set; }      
    }
}
