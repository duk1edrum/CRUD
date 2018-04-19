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
        public static StudentViewModel ToUserView(this StudentDTO studentDto)
        {
            return new StudentViewModel()
            {
                StudentId = studentDto.Id,
                Name = studentDto.Name,
                LastName = studentDto.LastName,
                Stipend = studentDto.Stipend,
                SizeStipend = studentDto.SizeStipend,
                //Courses = studentDto.Courses,
            };
        }

        public static StudentDTO ToUserDto(this StudentViewModel studentView)
        {
            return new StudentDTO()
            {
                Id = studentView.StudentId,
                Name = studentView.Name,
                LastName = studentView.LastName,
                Stipend = studentView.Stipend,
                SizeStipend = studentView.SizeStipend,
                //new Courses = studentView.Courses,
            };
        }
    }
}
