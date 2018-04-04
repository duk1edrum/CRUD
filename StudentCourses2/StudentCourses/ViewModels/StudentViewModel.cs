using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentCourses.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Stipend { get; set; }
        public int SizeStipend { get; set; }

       // public List<CheckBoxViewModel> Courses { get; set; }
    }
}
