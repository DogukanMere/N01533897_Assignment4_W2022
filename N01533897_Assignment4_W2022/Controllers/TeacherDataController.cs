using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using N01533897_Assignment4_W2022.Models;
using MySql.Data.MySqlClient;

namespace N01533897_Assignment4_W2022.Controllers
{
    public class TeacherDataController : ApiController
    {
        //Access the MySql Database

        private SchoolDbContext School = new SchoolDbContext();

        //This Controller will access the teachers table of our DB
        /// <summary>
        /// Returns a list of teachers by search
        /// </summary>
        /// <example> GET api/TeacherData/ListTeachers/{SearchKey}</example>
        /// <returns>
        /// <paramref name="SearchKey"/>
        /// a list of teachers (first names and last names) and if user input a search, it will match with the teachers' names
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
        {
            //Create a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between local db and web server
            Connection.Open();

            //New command - Query for DB
            MySqlCommand command = Connection.CreateCommand();

            //SQL Query
            string query = "Select * from Teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";

            command.CommandText = query;
            command.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            command.Prepare();


            //Gather results into a variable
            MySqlDataReader Result = command.ExecuteReader();

            //Create empty list to add each teacher
            List<Teacher> Teachers = new List<Teacher> { };

            //While loop for each row
            while (Result.Read())
            {
                //Access each column info by using db column names
                int TeacherId = Convert.ToInt32(Result["teacherid"]);
                string TeacherFname = Result["teacherfname"].ToString();
                string TeacherLname = Result["teacherlname"].ToString();
                string EmpyloyeeNumber = Result["employeenumber"].ToString();
                double Salary = Convert.ToDouble(Result["salary"]);


                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmpyloyeeNumber;
                NewTeacher.Salary = Salary;



                //Add teacher into the list created before the loop
                Teachers.Add(NewTeacher);
            }

            //Close the db connection
            Connection.Close();

            //Return list of teachers
            return Teachers;

        }


        /// This Controller will find a specific teacher with his/her id on DB table
        /// <summary>
        /// it will find a teacher in the system based on Teacher's id
        /// </summary>
        /// <param name="id"> teacher id </param>
        /// <returns>A teacher object</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            //Create a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between local db and web server
            Connection.Open();

            //New command - Query for DB
            MySqlCommand command = Connection.CreateCommand();

            //Write SQL query
            command.CommandText = "Select * from Teachers where teacherid = " + id;

            //Gather results into a variable
            MySqlDataReader Result = command.ExecuteReader();

            //Create an empty list to add selected teacher
            Teacher NewTeacher = new Teacher();


            //While loop for each row
            while (Result.Read())
            {
                //Access each column info by using db column names
                int TeacherId = Convert.ToInt32(Result["teacherid"]);
                string TeacherFname = Result["teacherfname"].ToString();
                string TeacherLname = Result["teacherlname"].ToString();
                string EmpyloyeeNumber = Result["employeenumber"].ToString();
                DateTime Hiredate = (DateTime)Result["hiredate"];
                double Salary = Convert.ToDouble(Result["salary"]);

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmpyloyeeNumber;
                NewTeacher.Hiredate = Hiredate;
                NewTeacher.Salary = Salary;

            }

            //Close the db connection
            Connection.Close();

            //Return list of teachers
            return NewTeacher;

        }

        //POST
        /// <summary>
        /// Write query to delete specific teacher based on his/her id
        /// </summary>
        /// <param name="id"> Id of the teacher</param>
        /// <example>POST /api/TeacherData/DeleteTeacher/5</example>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            //Create a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between local db and web server
            Connection.Open();

            //New command - Query for DB
            MySqlCommand command = Connection.CreateCommand();

            //Write SQL query
            command.CommandText = "delete from teachers where teacherid=@id";
            command.Parameters.AddWithValue("@id", id);
            command.Prepare();

            //Run the query in db
            command.ExecuteNonQuery();

            //Close the db connection
            Connection.Close();
        }

        //POST
        /// <summary>
        /// Create a new teacher in db by using query (insert into). 
        /// </summary>
        /// <param name="NewTeacher"> Created object which is holding all info given by user to insert into teachers table</param>
        /// <example> /api/TeacherData/AddTeacher
        /// FORM / POST DATA / REQUEST
        /// {
        ///     TeacherFname: "Luis";
        ///     TeacherLname: "Miguel";
        ///     EmployeeNumber: "T639";
        ///     Hiredate: "2022-02-09 00:00:00";
        ///     Salary: "62.48";
        /// }
        /// </example>
        [HttpPost]
        public void AddTeacher([FromBody]Teacher NewTeacher)
        {
            //Create a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between local db and web server
            Connection.Open();

            //New command - Query for DB
            MySqlCommand command = Connection.CreateCommand();

            //Write SQL query
            command.CommandText = "insert into teachers(teacherfname, teacherlname, employeenumber, hiredate, salary) values (@TeacherFname, @TeacherLname, @EmployeeNumber, @Hiredate, @Salary)";
            command.Parameters.AddWithValue("@Teacherfname", NewTeacher.TeacherFname);
            command.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            command.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.EmployeeNumber);
            command.Parameters.AddWithValue("@Hiredate", NewTeacher.Hiredate);
            command.Parameters.AddWithValue("@Salary", NewTeacher.Salary);
            command.Prepare();

            //Run the query in db
            command.ExecuteNonQuery();

            //Close the db connection
            Connection.Close();

        }

    }
}