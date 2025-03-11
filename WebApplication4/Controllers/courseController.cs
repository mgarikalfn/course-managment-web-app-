using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using WebApplication4.Data;


namespace WebApplication4.Controllers
{
    public class CourseController : Controller
    {
        private readonly COMSDbContext _context;
        public CourseController(COMSDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var CourseList = _context.Course.Include(x => x.Department).ToList();

            return View(CourseList);
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(_context.Department, "DepartmentID", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit (int? id)
        {
         if (id == null)
            {
                return NotFound();
            }
            var course = _context.Course.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            ViewBag.DepartmentList = new SelectList(_context.Department, "DepartmentID", "DepartmentName", course.DepartmentID);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int id, Course course)
        {
            var record = _context.Course.Find(id);

            if (record == null)
            {
                return NotFound();  // If course not found, return NotFound()
            }

            record.CourseName = course.CourseName;
            record.CourseCode = course.CourseCode;
            record.CreditHour = course.CreditHour;
            record.DepartmentID = course.DepartmentID;

            _context.SaveChanges(); // Save changes
            return RedirectToAction("Index"); // Redirect to the list page after saving
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _context.Course.FirstOrDefault(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // ✅ Fix the Delete method (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Course.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Course.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

