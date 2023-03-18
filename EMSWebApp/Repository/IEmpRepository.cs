using EMSWebApp.Models;

namespace EMSWebApp.Repository
{
    public interface IEmpRepository
    {
        List<Employee> index();
        Employee GetEmployeeById(int Id);
        List<department> getOptions();

        Employee AddEmployee(Employee newEmployee);

        Employee DeleteEmployee(int Id);
        Employee editEmp(int Id, Employee emp);
    }
}
