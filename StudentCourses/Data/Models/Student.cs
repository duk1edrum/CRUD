using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Stipend { get; set; }
        public int SizeStipend { get; set; }


        public ICollection<CourseToStudent> CoursesToStudents { get; set; }
        
    }
}
