using Microsoft.AspNetCore.Mvc;
using Project1.Models;

public class CourseController : Controller {
    private ICourseRepo repo;
    public CourseController(ICourseRepo db)
    {
        this.repo = db;
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Course course)
    {
        bool res = repo.AddCourse(course);
        if (res == true)
        {
            return Redirect("Index");
        }
        return View();
    }



    public IActionResult Index()
    {
        List<Course> list = repo.GetAll();
        return View(list);
    }
    public IActionResult Details(int id)
    {
        Course course = repo.GetDetails(id);



        return View(course);
    }
    public IActionResult Delete(int id)
    {
        bool res = repo.DeleteCourse(id);




        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        Course course = repo.GetDetails(id);
        return View(course);
    }
    [HttpPost]
    public IActionResult Update(Course c)
    {

        repo.Update(c);
        return Redirect("Index");
    }
}
