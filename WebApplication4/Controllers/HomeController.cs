using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Define struct correctly
    public struct Student
    {
        public string Name;
        public string Gender;


    }

    public IActionResult Index()
    {
        List<Student> students = new List<Student>();

        Student s1 = new Student();
        Student s2 = new Student();

        s1.Name = "tesfa";
        s1.Gender = "Male";

        s2.Name = "tesfa";
        s2.Gender = "Male";

        students.Add(s1);
        students.Add(s2);



        ViewBag.students = students;
        ViewBag.listSize = students.Count;

        ViewBag.Message = "First ASP.Net Core program";
        return View();
    }

   

    public IActionResult Course()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
