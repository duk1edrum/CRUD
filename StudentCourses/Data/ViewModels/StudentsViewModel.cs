﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class StudentsViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Stipend { get; set; }
        public int SizeStipend { get; set; }

        public List<CheckBoxViewModel> Courses { get; set; }
    }
}
