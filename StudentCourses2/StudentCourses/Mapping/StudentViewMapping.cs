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

        public static StudentDTO ToStudentDto(this StudentViewModel studentView)
        {
            return new StudentDTO()
            {
                Id = studentView.Id,
                Name = studentView.Name,
                LastName = studentView.LastName,
                Stipend = studentView.Stipend,
                SizeStipend = studentView.SizeStipend,
                //new Courses = studentView.Courses,
            };
        }
    }
}
