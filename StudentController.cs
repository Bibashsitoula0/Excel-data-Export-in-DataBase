using Api.Models;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UGC.DAL.CommonRepository;
using UGC.DAL;
using UGC.Service.AccountService;
using UGC.Service.CurrentUserService;
using UGC.Service.StudentService;
using UGC.Model;
using System.Data;
using Api.Helpers;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting.Server;
using UGC.Service.OTPService;
using System.Net.Mime;
using System.Text;
using System.IO;
using static System.Net.WebRequestMethods;
using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       private IStudentService _studentService;
        private IWebHostEnvironment _hostingEnvironment;

        public StudentController(IStudentService studentService, IWebHostEnvironment hostingEnvironment)
        {
            _studentService = studentService;
            _hostingEnvironment = hostingEnvironment;
        }

      
        [Route("Excelupload")]
        [HttpPost]
        public ActionResult ExcelUpload(IFormFile file)
        {
            try
            {
                 string pathToExcelFile = "";
         

                if (file != null)
                {
                    if (file.ContentType == "application/vnd.ms-excel" || file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || file.ContentType == "application/vnd.ms-excel.sheet.macroEnabled.12")
                    {
                        string filename = file.FileName;
                        string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Attachments"));
                        using (var fileStream = new FileStream(Path.Combine(path , filename), FileMode.Create))
                        {
                             file.CopyToAsync(fileStream);
                        }
                        pathToExcelFile = Path.Combine(path, filename);
                         var res = _studentService.UploadExcel(pathToExcelFile);
                       }
                    else
                        return this.Failed("File format not supported !!");
                }
                return this.Failed("File Uploaded Sucessfully");
            }
            catch (Exception ex)
            {
                return this.Failed(ex.Message);
            }
        }
        protected ActionResult Failed(string message)
        { 
            return this.Content(message, MediaTypeNames.Text.Plain, Encoding.UTF8);
        }

    }
}
