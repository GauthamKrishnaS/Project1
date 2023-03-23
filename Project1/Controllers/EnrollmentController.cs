using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Project1.Models;
using Project1.Repository;

namespace Project1.Controllers {
    public class EnrollmentController : Controller {
        private IEnrollmentRepo enroll;
        public EnrollmentController(IEnrollmentRepo _enroll)
        {
            enroll = _enroll;
        }

        [HttpGet]
        public IActionResult AddEnrollment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEnrollment(Enrollment enrollment)
        {
            enroll.AddEnrollment(enrollment);
            return RedirectToAction("Details");
            
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View(enroll.GetEnrollments());
        }

        [HttpGet]
        public IActionResult DetailsByCourse(int id) 
        {
            return View(enroll.GetEnrollmentsByCourse(id));
        }

        [HttpGet]
        public IActionResult CourseList()
        {
            return View(enroll.GetCourses());   
        }
    }
}
