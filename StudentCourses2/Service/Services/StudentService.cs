using AutoMapper;
using Data.Context;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Service.DTO;
using Service.Infrastructure;
using Service.Interfaces;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        IUnitOfWork Database { get; set; }
        public StudentService()
        {
            Database = new EFUnitOfWork();
        }

        public StudentService(IUnitOfWork uow)
        {
            Database = uow;
        }
        

        public IEnumerable<StudentDTO> GetStudents()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(Database.Students.GetAll());
        }

        public StudentDTO GetStudent(int? id)
        {
            if (id == null)
                throw new ValidationException("Student Id not Found", "");
           StudentDTO studentDto = StudentMapping.ToStudentDto(Database.Students.Get(id));
            if (studentDto == null)
                throw new ValidationException("Student Not Found", "");
            return studentDto;

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Create(StudentDTO studentDTO)
        {
            Database.Students.Create(StudentMapping.ToStudent(studentDTO));
            Database.Students.Save();
        }

        public void Update(StudentDTO studentDTO)
        {
            var entity = Database.Students.Get(studentDTO.Id);

            studentDTO.ToStudent(entity);

            Database.Students.Update(entity);

            Database.Students.Save();
        }

        public void Delete(int? id)
        {
            Database.Students.Delete(id.Value);
            Database.Students.Save();
        }

        
    }
}
