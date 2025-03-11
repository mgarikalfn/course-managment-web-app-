using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class SemesterController : Controller
    {
        private readonly COMSDbContext _context;

        public SemesterController(COMSDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var semesterList = _context.Semester.Include(x => x.Courses).ToList();
            return View(semesterList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Semester semester)
        {
            
            
                _context.Semester.Add(semester);
                _context.SaveChanges();
                return RedirectToAction("Index");
           
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var semester = _context.Semester.Find(id);
            if (semester == null)
            {
                return NotFound();
            }
            return View(semester);
        }

        [HttpPost]
        public IActionResult Edit(int id, Semester semester)
        {
            var record = _context.Semester.Find(id);
            if (record == null)
            {
                return NotFound();
            }

            record.SemesterName = semester.SemesterName;
            record.SemesterNo = semester.SemesterNo;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // ✅ Add the Delete method (GET)
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = _context.Semester.FirstOrDefault(m => m.SemesterId == id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        // ✅ Fix the Delete method (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var semester = _context.Semester.Find(id);
            if (semester == null)
            {
                return NotFound();
            }

            _context.Semester.Remove(semester);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
