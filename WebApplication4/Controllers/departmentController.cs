using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly COMSDbContext _context;

        public DepartmentController(COMSDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public IActionResult Index()
        {
            var departmentList = _context.Department
                .Include(d => d.Courses) // Include related Courses
                .Include(d => d.Instructors) // Include related Instructors
                .ToList();
            return View(departmentList);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        public IActionResult Create(Department department)
        {
            
            
                _context.Department.Add(department); // Add department to the database
                _context.SaveChanges(); // Save changes
               return RedirectToAction("Index"); // Redirect to the list page after saving
            

            
        }

        // GET: Departments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }

            
                var record = _context.Department.Find(id);

                if (record == null)
                {
                    return NotFound();
                }

                // Update department properties
                record.DepartmentName = department.DepartmentName;
                record.DepartmentAcronym = department.DepartmentAcronym;

                _context.SaveChanges(); // Save changes
                return RedirectToAction("Index"); // Redirect to the list page after saving
            }



        // GET: Departments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Department.FirstOrDefault(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // ✅ Fix the Delete method (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Department.Remove(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}