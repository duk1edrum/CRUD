using Data.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mapping
{
   public static  class CourseMapping
    {
        public static CourseDTO ToCourseDto(this Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                Name = course.Name,
                Free = course.Free,
                Room = course.Room,
                           };
        }

        public static void ToCourse(this CourseDTO courseDto, Course course)
        {
            course.Id = courseDto.Id;
            course.Name = courseDto.Name;
            course.Room = courseDto.Room;
            course.Free = courseDto.Free;
           // course.Students = courseDto.studentDTOs;
        }

        public static Course ToCourse(this CourseDTO courseDto)
        {
            var ent = new Course();
            courseDto.ToCourse(ent);
            return ent;
        }
    }
}
