using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGC.DAL.Entities;
using UGC.Model;

namespace UGC.DAL.StudentRepository
{
    public interface IStudentRepository
    {
        Task<List<StudentNeb>> GetStudent(int? pageNumber, int? pageSize);
        Task<List<StudentNeb>> GetStudentById(int Id);
        Task<List<StudentNeb>> GetStudentByNEBId(string nebID);
        Task<int> InsertStudentAsync(StudentNeb model);
        Task<bool> UpdateStudentAsync(StudentNeb model);
        Task<bool> DeleteStudent(StudentNeb model);
        Task<List<StudentNeb>> GetStudentNebAsyncId(long Id);
        Task<List<StudentNeb>> GetStudentListInExcel();
        Task<bool> UploadExcel(string file);
    }
}
