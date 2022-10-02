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
       
        public readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
          
            _studentRepository = studentRepository;
        }

        public async Task<bool> UploadExcel(string pathToExcelFile)
        {
            
              return await _studentRepository.UploadExcel(pathToExcelFile);
            

        }
    }
}
