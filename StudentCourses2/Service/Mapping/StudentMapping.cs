using Data.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mapping
{
    public static class StudentMapping
    {
        public static StudentDTO ToStudentDto(this Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Stipend = student.Stipend,
                SizeStipend = student.Amount,
                //Courses = student.Courses,
            };
        }

        public static void  ToStudent(this StudentDTO studentDto, Student student)
        {
            
            {
                student.Id = studentDto.Id;
                student.Name = studentDto.Name;
                student.LastName = studentDto.LastName;
                student.Amount = studentDto.SizeStipend;
                student.Stipend = studentDto.Stipend;
               //Courses = studentDto.Courses,
               //User = studentDto.UserDto,
            };
        }

        public static Student ToStudent(this StudentDTO studentDto)
        {
            var entity = new Student();
            studentDto.ToStudent(entity);
            return entity;
        }
    }
}
