using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N01533897_Assignment4_W2022.Models;
using System.Diagnostics;

namespace N01533897_Assignment4_W2022.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET: Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);

            return View(Teachers);
        }

        //GET: Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        //POST: /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //reach api controller and delete teacher based on teacher's id 
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            //After delete, direct to teacher list
            return RedirectToAction("List");
        }


        //GET : /Teacher/New
        //Page to add new teacher
        public ActionResult Add()
        {
            return View();
        }


        //POST /Teacher/Create
        //It will get a new teacher information and after submission, it will add it into db
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime Hiredate, double Salary)
        {

            //Add all given inputs into an object
            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Hiredate = Hiredate;
            NewTeacher.Salary = Salary;

            //Reach Api controller and call AddTeacher, let the query insert into the db
            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            //After submission show teacher list
            return RedirectToAction("List");
        }
    }
}