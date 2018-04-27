using Service.DTO;
using StudentCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourses.Mapping
{
    public static class CourseViewMapping
    {
        public static CourseViewModel ToCourseView(this CourseDTO courseDto)
        {
            return new CourseViewModel()
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Free = courseDto.Free,
                Room = courseDto.Room,
                
                //Courses = studentDto.Courses,
            };
        }

        public static void ToCourseDto(this CourseViewModel courseView, CourseDTO courseDTO)
        {

            {
                courseDTO.Id = courseView.Id;
                courseDTO.Name = courseView.Name;
                courseDTO.Room = courseView.Room;
                courseDTO.Free = courseView.Free;
                //courseDTO.studentDTOs = courseView.Students;

            };
        }

        public static CourseDTO ToCourseDTO(this CourseViewModel courseView)
        {
            var ent = new CourseDTO();
            courseView.ToCourseDto(ent);
            return ent;
        }
    }
}