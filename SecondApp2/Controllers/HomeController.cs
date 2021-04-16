using SecondApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondApp2.Repositories;

namespace SecondApp2.Controllers
{
    public class HomeController : Controller
    {
        studentContext stucon =new studentContext();
        CustomerContext cusCon = new CustomerContext();
     

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CreateStudent()
        {
            return View();
        }
        public void InsertStudent(student student)
        {
            stucon.InsertStudent(student);
        }

        //update works are done from here
        public JsonResult GetStudents()
        {
            List<student> students = stucon.GetStudents();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
        //customers creation froom here....
        public ActionResult CreateCustomer()
        {
            return View();
        }
        public void InsertCustomer(customer customer)
        {
            cusCon.InsertCustomer(customer);
        }
        //update works are done from here
        public JsonResult GetCustomers()
        {
            List<customer> customers = cusCon.GetCustomers();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        //deleted works done from here...
        public void DeleteCustomer(int Id)
        {
            cusCon.DeleteCustomer(Id);
        }

    }
}