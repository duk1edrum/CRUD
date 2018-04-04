using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
   public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Stipend { get; set; }
        public int SizeStipend { get; set; }
    }
}
