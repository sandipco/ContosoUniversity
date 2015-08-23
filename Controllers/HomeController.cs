using ContosoUniversity8_22.DAL;
using ContosoUniversity8_22.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity8_22.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from student in db.Students
                                                   group student by student.EnrollmentDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       StudentCount = dateGroup.Count(),                                                       
                                                   };
            int i = data.Count();
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}