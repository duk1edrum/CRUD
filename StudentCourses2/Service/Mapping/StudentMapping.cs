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

        public static Student ToStudent(this StudentDTO studentDto)
        {
            return new Student()
            {
                Id = studentDto.Id,
                Name = studentDto.Name,
                LastName = studentDto.LastName,
                Amount = studentDto.SizeStipend,
               Stipend = studentDto.Stipend,
               //Courses = studentDto.Courses,
               //User = studentDto.UserDto,
            };
        }
    }
}
