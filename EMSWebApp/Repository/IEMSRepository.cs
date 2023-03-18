using EMSWebApp.Models;

namespace EMSWebApp.Repository
{
    public interface IEMSRepository
    {
        List<department> index();
        department GetDeptById(int Id);
        department Adddepartment(department newDept);
        department DeleteDept(int Id);
        department editDept(int deptId, department dept);
    }
}
