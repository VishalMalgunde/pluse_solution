using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pluse_solution.Models;

namespace pluse_solution.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DbEntities _db;

        public EmployeesController(DbEntities db)
        {
            _db = db;
        }

        // GET: EmployeesController
        public IActionResult Index()
        {
            List<Employee> _employees = _db.Employees.ToList();

            return View(_employees);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            Employee employees = new Employee();
            return View(employees);
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Employees.Add(employee);
                    _db.SaveChanges();
                    TempData["SuccMsg"] = "Employee added successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error saving employee: " + ex.Message);
                    return View(employee);
                }
            }
            else
            {
                ViewBag.ErrMsg = string.Join("<br />", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }
            return View(employee);
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = _db.Employees.Find(id);
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Entry(employee).State = EntityState.Modified;
                    _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ModelState.AddModelError("", "Error saving employee: " + ex.Message);
                    return View(employee);
                }
            }
            else
            {
                ViewBag.ErrMsg = string.Join("<br />", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }
            return View(employee);
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = _db.Employees.Find(id);

            if (employee == null)
            {
                TempData["ErrMsg"] = "Employee not found.";
                return View("Reload");
            }

            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                employee = _db.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                _db.Employees.Remove(employee);
                _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error deleting employee: " + ex.Message);
                return View();
            }
        }
    }
}
