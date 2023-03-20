using EMSWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSWebApp.Repository.InMemory
{
    public class DeptInMemoryRepository : IEMSRepository
    {
        static List<department> dept = new List<department>();

        static DeptInMemoryRepository()
        {
            dept.Add(new department(1, "IT"));
            dept.Add(new department(2, "Devops"));
            dept.Add(new department(3, "QA"));
        }
        public List<department> index()
        {
            return dept;
        }
        public department Adddepartment(department newDept)
        {

            newDept.Id = dept.Max(x => x.Id) + 1; // max id of your list
            dept.Add(newDept);
            return newDept;

        }


        public department DeleteDept(int Id)
        {
            var oldDept = dept.Find(x => x.Id == Id);
            if (oldDept == null)
                return null;
            dept.Remove(oldDept);
            return oldDept;
        }
        public department GetDeptById(int Id)
        {
            return dept.FirstOrDefault(x => x.Id == Id);
        }
        public department editDept(int deptId, department department)
        {
            var oldDept = dept.Find(x => x.Id == deptId);
            if (oldDept == null)
                return null;
            dept.Remove(oldDept);
            dept.Add(department);
            return department;
        }
    }
}
