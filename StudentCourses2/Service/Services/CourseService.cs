using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Service.DTO;
using Service.Interfaces;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Services
{
   public class CourseService:ICourseService
    {
        IUnitOfWork Database { get; set; }
        public CourseService()
        {
            Database = new EFUnitOfWork();
        }

        public CourseService(IUnitOfWork uow)
        {
            Database = uow;
        }


        public IEnumerable<CourseDTO> GetCourses()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Course, CourseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Course>, List<CourseDTO>>(Database.Courses.GetAll());
        }

        public CourseDTO GetCourse(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Course Id not Found");

            }
            var dto = Database.Courses.Get(id);
            var courseDto = CourseMapping.ToCourseDto(dto);
            
            if (courseDto == null)
                throw new ValidationException("Student Not Found");
            return courseDto;

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Create(CourseDTO courseDTO)
        {
            var dto = CourseMapping.ToCourse(courseDTO);
            Database.Courses.Create(dto);
            Database.Courses.Save();
        }

        public void Update(CourseDTO courseDTO)
        {
            var entity = Database.Courses.Get(courseDTO.Id);

            courseDTO.ToCourse(entity);

            Database.Courses.Update(entity);

            Database.Courses.Save();
        }

        public void Delete(int? id)
        {
            Database.Courses.Delete(id.Value);
            Database.Courses.Save();
        }
    }
}
