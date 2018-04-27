using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ICourseService
    {
        CourseDTO GetCourse(int? id);
        IEnumerable<CourseDTO> GetCourses();
        void Dispose();

        void Create(CourseDTO courseDTO);
        void Update(CourseDTO courseDTO);
        void Delete(int? id);

    }
}
