using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Assignment.Data;
using MVC_Assignment.Models;

namespace MVC_Assignment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;
        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = _context.Departments.Include(d => d.Students).ToList();
            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var department = _context.Departments.Include(d => d.Students).FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department department)
        {

            _context.Departments.Add(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            _context.Update(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var department = _context.Departments.Include(d => d.Students).FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
