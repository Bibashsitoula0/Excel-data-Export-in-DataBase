using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UGC.DAL;
using UGC.DAL.AdminRepository;
using UGC.DAL.Entities;
using UGC.DAL.OTPRepository;
using UGC.DAL.StudentRepository;
using UGC.Model;
using UGC.Service.CurrentUserService;
using static Slapper.AutoMapper;

namespace UGC.Service.StudentService
{
    public class StudentService : IStudentService
    {
        public IDataAccessLayer _dah;
        public readonly IStudentRepository _studentRepository;
        public StudentService(IDataAccessLayer dah, IStudentRepository studentRepository)
        {
            _dah = dah;
            _studentRepository = studentRepository;
        }

        public async Task<StudentNeb> Create(StudentNeb model)
        {
            var id = await _studentRepository.InsertStudentAsync(model);
            return model;
        }
        public async Task<List<StudentNeb>> GetStudent(int? pageNumber, int? pageSize)
        {
            var data = await _studentRepository.GetStudent(pageNumber, pageSize);
            return data;
        }
        public async Task<List<StudentNeb>> GetStudentById(int Id)
        {
            var data = await _studentRepository.GetStudentById(Id);
            return data;
        }
        public async Task<List<StudentNeb>> GetStudentByNEBId(string nebID)
        {
            var data = await _studentRepository.GetStudentByNEBId(nebID);
            return data;
           
        }
        

        public async Task<bool> UpdateStudent(StudentNeb model)
        {
            return await _studentRepository.UpdateStudentAsync(model);
        }

        public async Task<bool> DeleteStudent(StudentNeb model)
        {
            return await _studentRepository.DeleteStudent(model);
        }

        public async Task<List<StudentNeb>> GetStudentListInExcel()
        {
            var data = await _studentRepository.GetStudentListInExcel();
            return data;
        }

        public async Task<bool> UploadExcel(string pathToExcelFile)
        {
            
              return await _studentRepository.UploadExcel(pathToExcelFile);
            

        }
    }
}
