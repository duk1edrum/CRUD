using Service.DTO;
using StudentCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourses.Mapping
{
    public static class StudentViewMapping
    {
        public static StudentViewModel ToStudentView(this StudentDTO studentDto)
        {
            return new StudentViewModel()
            {
                Id = studentDto.Id,
                Name = studentDto.Name,
                LastName = studentDto.LastName,
                Stipend = studentDto.Stipend,
                SizeStipend = studentDto.SizeStipend,
                //Courses = studentDto.Courses,
            };
        }

        public static void ToStudentDto(this StudentViewModel studentView,StudentDTO studentDTO)
        {
            
            {
                studentDTO.Id = studentView.Id;
                studentDTO.Name = studentView.Name;
                studentDTO.LastName = studentView.LastName;
                studentDTO.Stipend = studentView.Stipend;
                studentDTO.SizeStipend = studentView.SizeStipend;
                //new Courses = studentView.Courses,
            };
        }

        public static StudentDTO ToStudentDTO(this StudentViewModel studentView)
        {
            var ent = new StudentDTO();
            studentView.ToStudentDto(ent);
            return ent;
        }
    }
}
