using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N01533897_Assignment4_W2022.Models
{
    public class Teacher
    {
        //These fields created based on teacher DB columns in the system
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime Hiredate;
        public double Salary;

        public Teacher() { }
    }
}