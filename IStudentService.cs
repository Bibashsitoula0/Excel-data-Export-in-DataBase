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

        Task<bool> UploadExcel(string pathToExcelFile);

    }
}
