using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentInfo.Entity;
using StudentInfo.Models;

namespace StudentInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentInfoDbContext context;
        public HomeController(ILogger<HomeController> logger, StudentInfoDbContext db)
        {
            _logger = logger;
            this.context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ReturnSet SaveStudentInfo(Student data)
        {
            ReturnSet result = new ReturnSet();
            result.ReturnValue = -501;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sprocInsertStudentInfo", sqlConnection))
                    {
                        sqlConnection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@StudentID", (object)data.StudentID??0);
                        cmd.Parameters.AddWithValue("@Provider", (object)data.Provider??"");
                        cmd.Parameters.AddWithValue("@FacultyID", (object)data.FacultyID??0);
                        cmd.Parameters.AddWithValue("@CourseCode", (object)data.CourseCode??"");
                        cmd.Parameters.AddWithValue("@CourseCredit", (object)data.CourseCredit??0);

                        cmd.Parameters.Add("@oRetVal", SqlDbType.Int);
                        cmd.Parameters["@oRetVal"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@oMasterScheduleId", SqlDbType.Int);
                        cmd.Parameters["@oMasterScheduleId"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@oStudentScheduleId", SqlDbType.Int);
                        cmd.Parameters["@oStudentScheduleId"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        result.ReturnValue = Convert.ToInt32(cmd.Parameters["@oRetVal"].Value);
                        result.MasterScheduleId = Convert.ToInt32(cmd.Parameters["@oMasterScheduleId"].Value);
                        result.StudentScheduleId = Convert.ToInt32(cmd.Parameters["@oStudentScheduleId"].Value);

                        sqlConnection.Close();
                    }

                }
                return result;
            }
            catch (Exception ex)
            {                
                return new ReturnSet() { ReturnValue = -501 };
            }
        }
    }
}
