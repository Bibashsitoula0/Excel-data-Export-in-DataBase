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
        Task<bool> UploadExcel(string file);
    }
}
