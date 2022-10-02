using Dapper.Contrib.Extensions;
using LinqToExcel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UGC.DAL.Entities;
using UGC.Model;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace UGC.DAL.StudentRepository
{
    public class StudentRepository : DALConfig, IStudentRepository
    {
        public readonly IDataAccessLayer _dah;
        public StudentRepository(IDataAccessLayer dah)
        {
            _dah = dah;

        }
        public async Task<List<StudentNeb>> GetStudentById(int Id)
        {
            string query = @"select * from student_neb
             where id = @id";
            var parameters = new { id = Id };
            var user = await _dah.FetchDerivedModelAsync<StudentNeb>(query, parameters);
            return user;
        }

        public async Task<List<StudentNeb>> GetStudent(int? pageNumber, int? pageSize)
        {
            var parameters = new { pageNumber = pageNumber, pageSize = pageSize };
            string query = @"select * from student_neb
            offset ((@pageNumber -1)*@pageSize) rows fetch next (@pageSize) rows only";

            var user = await _dah.FetchDerivedModelAsync<StudentNeb>(query, parameters);
            return user;
        }
        public async Task<List<StudentNeb>> GetStudentListInExcel()
        {
            string query = @"select * from student_neb";

            var user = await _dah.FetchDerivedModelAsync<StudentNeb>(query);
            return user;
        }

        public async Task<bool> DeleteStudent(StudentNeb model)
        {
            using (IDbConnection db = GetDbConnection())
            {
                var isSuccess = await db.DeleteAsync(model);
                return isSuccess;
            }
        }

        public async Task<int> InsertStudentAsync(StudentNeb model)
        {
            using (IDbConnection db = GetDbConnection())
            {
                var id = await db.InsertAsync(model);
                return id;
            }
        }

        public async Task<bool> UpdateStudentAsync(StudentNeb model)
        {
            using (IDbConnection db = GetDbConnection())
            {
                var isSuccess = await db.UpdateAsync(model);
                return isSuccess;
            }
        }

        public async Task<List<StudentNeb>> GetStudentNebAsyncId(long _student_id)
        {
            string query = @"select * from student_neb
                            where student_id = @studentid
";
            var parameters = new { studentid = _student_id };
            var data = await _dah.FetchDerivedModelAsync<StudentNeb>(query, parameters);
            return data;
        }

        public async Task<List<StudentNeb>> GetStudentByNEBId(string nebID)
        {
            string query = @"select * from student_neb
             where neb_id = @id";
            var parameters = new { id = nebID };
            var user = await _dah.FetchDerivedModelAsync<StudentNeb>(query, parameters);
            return user;
        }
        public async Task<bool> UploadExcel(string file)
        {
            using (IDbConnection db = GetDbConnection())
            {

                List<StudentNeb> list = new List<StudentNeb>();
                try
                {

                    string sheetName = "Sheet1";
                    var excelFile = new ExcelQueryFactory(file);
                    var data = from a in excelFile.Worksheet(sheetName) select a;
                   
                    foreach (var a in data)
                    {
                        if (!String.IsNullOrEmpty(a["Id"].Value.ToString()))
                        {
                            StudentNeb excelD = new StudentNeb();
                            excelD.id = Int64.Parse(a["Id"]);
                            excelD.neb_id = a["Neb Id"].Value.ToString();
                            excelD.student_name = a["Student Name"].Value.ToString();
                            excelD.mobile_no = a["Mobile"].Value.ToString();
                            excelD.email = a["Email"].Value.ToString();
                            var id = excelD.id;
                            if (id != 0)
                            {
                                var result = await db.InsertAsync(excelD);
                                list.Add(excelD);
                            }

                        }
                    }
                    if ((System.IO.File.Exists(file)))
                    {
                        System.IO.File.Delete(file);
                    }

                }


                catch (Exception)
                {
                    if ((System.IO.File.Exists(file)))
                    {
                        System.IO.File.Delete(file);
                    }


                }
            }
            return true;


        }
    }


}


