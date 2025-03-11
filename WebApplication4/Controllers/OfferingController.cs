using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class OfferingController(COMSDbContext context) : Controller
    {
        private readonly COMSDbContext _context = context;


        public IActionResult Index()
        {
            var offering = _context.Offering.Include(x => x.Course)
                .ThenInclude(x => x.Department)// Include Course
                .Include(x => x.Instructor)
                .ToList();
            return View(offering);
        }

        // GET: Department/Create
        public IActionResult Create()
        {

            ViewBag.CourseList = new SelectList(_context.Course, "CourseId", "CourseName");
            ViewBag.InstructorList = new SelectList(_context.Instructor, "InstructorId", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Offering offering)
        {

            _context.Offering.Add(offering);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offering = _context.Offering.Find(id);
            if (offering == null)
            {
                return NotFound();
            }

            ViewBag.CourseList = new SelectList(_context.Course, "CourseId", "CourseName", offering.CourseId);
            ViewBag.InstructorList = new SelectList(_context.Instructor, "InstructorId", "Name", offering.InstructorId);
            return View(offering);
        }

        [HttpPost]
        public IActionResult Edit(int id, Offering offering)
        {
            if (id != offering.OfferingID)
            {
                return NotFound();
            }



            try
            {
                _context.Update(offering);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferingExists(offering.OfferingID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");



        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offering = _context.Offering.FirstOrDefault(m => m.OfferingID == id);
            if (offering == null)
            {
                return NotFound();
            }

            return View(offering);
        }

        // ✅ Fix the Delete method (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var offering = _context.Offering.Find(id);
            if (offering == null)
            {
                return NotFound();
            }

            _context.Offering.Remove(offering);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        private bool OfferingExists(int id)
        {
            return _context.Offering.Any(e => e.OfferingID == id);
        }



    }
}

