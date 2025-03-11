using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    public class InstructorController : Controller
    {
        private readonly COMSDbContext _context;

        public InstructorController(COMSDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var InstructorList = _context.Instructor.Include(x => x.Department).ToList();
            return View(InstructorList);
        }
        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(_context.Department, "DepartmentID", "DepartmentName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            _context.Instructor.Add(instructor); // Add course to the database
            _context.SaveChanges(); // Save changes
            return RedirectToAction("Index"); // Redirect to the list page after saving
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = _context.Instructor.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            ViewBag.DepartmentList = new SelectList(_context.Department, "DepartmentID", "DepartmentName", instructor.DepartmentID);
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Instructor instructor)
        {
            var record = _context.Instructor.Find(id);

            if (record == null)
            {
                return NotFound();  // If course not found, return NotFound()
            }

            record.Name = instructor.Name;
            record.Gender = instructor.Gender;
            record.ARank = instructor.ARank;
            record.DepartmentID = instructor.DepartmentID;

            _context.SaveChanges(); // Save changes
            return RedirectToAction("Index"); // Redirect to the list page after saving
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = _context.Instructor.FirstOrDefault(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // ✅ Fix the Delete method (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = _context.Instructor.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructor.Remove(instructor);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
