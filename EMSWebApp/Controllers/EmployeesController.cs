using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMSWebApp.Data;
using EMSWebApp.Models;
using EMSWebApp.Repository;

namespace EMSWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        IEmpRepository _repo;

        // tightly coupled object 
        //ITodoRepository _repo = new InMemoryRepository();
        //ITodoRepository _repo1 = new DBRepository();

        // lossely coupled implementation

        public EmployeesController(IEmpRepository repo)
        {
            _repo = repo;
            
        }
        public IActionResult index()
        {
            var emp = _repo.index();
            return View(emp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.options = new SelectList(_repo.getOptions(),"Id", "Name");
            Employee model = new Employee();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            
                var Emp = _repo.AddEmployee(newEmployee);
                return RedirectToAction("index");
            
        }

        public IActionResult Delete(int Id)
        {
            var dept = _repo.DeleteEmployee(Id);
            return RedirectToAction(controllerName: "Employees", actionName: "index");
        }

        [HttpGet]
        public IActionResult edit(int Id)
        {
            ViewBag.options = new SelectList(_repo.getOptions(), "Id", "Name");
            var oldEmp = _repo.GetEmployeeById(Id);
            return View(oldEmp);
        }
        [HttpPost]
        public IActionResult edit(Employee emp)
        {
            var employee = _repo.editEmp(emp.Id, emp);
            return RedirectToAction("index");
        }
        public IActionResult Details(int Id)
        {
            var emp = _repo.GetEmployeeById(Id);
            return View(emp);
        }


        //scafold
        /*private readonly EmsDbContext _context;

        public EmployeesController(EmsDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var emsDbContext = _context.Employees.Include(e => e.department);
            return View(await emsDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["departmentId"] = new SelectList(_context.Department, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,dob,email,Phone,departmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmentId"] = new SelectList(_context.Department, "Id", "Id", employee);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["departmentId"] = new SelectList(_context.Department, "Id", "Id", employee.departmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,dob,email,Phone,departmentId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmentId"] = new SelectList(_context.Department, "Id", "Id", employee.departmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'EmsDbContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
