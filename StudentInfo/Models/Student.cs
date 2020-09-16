using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Provider { get; set; }
        public int FacultyID { get; set; }
        public string CourseCode { get; set; }
        public decimal CourseCredit { get; set; }
    }

    public class ReturnSet
    {
        public int ReturnValue { get; set; }
        public int MasterScheduleId { get; set; }
        public int StudentScheduleId { get; set; }
    }
}
