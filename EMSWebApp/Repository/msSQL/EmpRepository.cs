using EMSWebApp.Data;
using EMSWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;

namespace EMSWebApp.Repository.msSQL
{
    public class EmpRepository : IEmpRepository
    {
        EmsDbContext _dbContext;

        public EmpRepository(EmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Employee> index()
        {
            return _dbContext.Employees.Include(e => e.department).AsNoTracking().ToList();
        }
        public List<department> getOptions()
        {

            return _dbContext.Department.ToList();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _dbContext.Employees.AsNoTracking().ToList().FirstOrDefault(emp => emp.Id == Id);
        }

        public Employee AddEmployee(Employee newEmployee)
        {
            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }
        public Employee DeleteEmployee(int Id)
        {
            var del = GetEmployeeById(Id);
            if (del != null)
            {
                _dbContext.Remove(del);
                _dbContext.SaveChanges();
            }
            return del;
        }

        public Employee editEmp(int Id, Employee emp)
        {
            _dbContext.Employees.Attach(emp);
            _dbContext.Update(emp);
            _dbContext.SaveChanges();
            return emp;
        }
    }
}
