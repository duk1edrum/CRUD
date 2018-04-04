using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public  interface IStudentService
    {
        StudentDTO GetStudent(int? id);
        IEnumerable<StudentDTO> GetStudents();
        void Dispose();

        //StudentDTO Create();
        //StudentDTO Update();
        //StudentDTO Delete();
    }
}
