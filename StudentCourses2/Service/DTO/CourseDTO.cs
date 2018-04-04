using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
   public  class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Room { get; set; }
        public bool Free { get; set; }
    }
}
