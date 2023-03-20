using EMSWebApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Immutable;
using static NuGet.Packaging.PackagingConstants;
namespace EMSWebApp.Repository.InMemory
{
    public class EmpImMemoryRepository : IEmpRepository
    {
        static List<Employee> employees = new List<Employee>();

        static List<department> department = new List<department>();

        static EmpImMemoryRepository()
        {
            employees.Add(new Employee(1, "Jean", DateTime.Now.AddDays(1), "LJOLAGUER@GMAIL.COM", "09194653567", 1));
            employees.Add(new Employee(2, "lHENER ", DateTime.Now.AddDays(1), "LJOLAGUER@GMAIL.COM", "09194653567", 1));
            employees.Add(new Employee(3, "Olaguer", DateTime.Now.AddDays(1), "LJOLAGUER@GMAIL.COM", "09194653567", 1));
        }
        public List<Employee> index()
        {
            return employees;
        }
        public Employee GetEmployeeById(int Id)
        {
            return employees.FirstOrDefault(x => x.Id == Id);
        }
       public List<department> getOptions()
        {
            return department.ToList();
        }
       
        public Employee AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = employees.Max(x => x.Id) + 1; // max id of your list
            employees.Add(newEmployee);
            return newEmployee;
        }

        public Employee DeleteEmployee(int Id)
        {
            var oldEmp = employees.Find(x => x.Id == Id);
            if (oldEmp == null)
                return null;
            employees.Remove(oldEmp);
            return oldEmp;
        }
        public Employee editEmp(int Id, Employee emp)
        {
            var oldEmp = employees.Find(x => x.Id == Id);
            if (oldEmp == null)
                return null;
            employees.Remove(oldEmp);
            employees.Add(emp);
            return emp;
        }

    }
}
