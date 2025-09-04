using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Data;
using Microsoft.EntityFrameworkCore;

namespace MVC_Assignment.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = _context.Students.Include(s => s.Department).ToList();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = _context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(MVC_Assignment.Models.Student student)
        {

            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Departments = _context.Departments.ToList();
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MVC_Assignment.Models.Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            _context.Update(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
