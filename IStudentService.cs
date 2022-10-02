using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGC.DAL.Entities;
using UGC.Model;

namespace UGC.Service.StudentService
{
    public interface IStudentService
    {   
        Task<StudentNeb> Create(StudentNeb model);
        Task<List<StudentNeb>> GetStudent(int? pageNumber,int? pageSize);
        Task<bool> UpdateStudent(StudentNeb model);
        Task<List<StudentNeb>> GetStudentById(int Id);
        Task<List<StudentNeb>> GetStudentByNEBId(string nebID);
        Task<bool> DeleteStudent(StudentNeb model);
        Task<List<StudentNeb>> GetStudentListInExcel();
        Task<bool> UploadExcel(string pathToExcelFile);

    }
}
