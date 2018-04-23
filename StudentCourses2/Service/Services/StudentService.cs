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

        public void Create()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();


            //return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(Database.Students.Create());
           // var studentCreate = Database.Students.Create();

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
        }

        public void Update(StudentDTO studentDTO)
        {
            Database.Students.Update(StudentMapping.ToStudent(studentDTO));
        }

        public void Delete(StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            Database.Students.Save();
        }
    }
}
