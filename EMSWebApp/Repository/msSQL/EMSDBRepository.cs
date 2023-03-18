using EMSWebApp.Data;
using EMSWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMSWebApp.Repository.msSQL
{
    public class EMSDBRepository : IEMSRepository
    { 
        EmsDbContext _dbContext;

        public EMSDBRepository( EmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<department> index()
        {
            return _dbContext.Department.AsNoTracking().ToList();
        }
        public department Adddepartment(department newDept)
        {
            _dbContext.Add(newDept);
            _dbContext.SaveChanges();
            return newDept;
        }
       

        public department DeleteDept(int Id)
        {
            var del = GetDeptById(Id);
            if (del != null)
            {
                _dbContext.Remove(del);
                _dbContext.SaveChanges();
            }
            return del;
        }
        public department GetDeptById(int Id)
        {
            return _dbContext.Department.AsNoTracking().ToList().FirstOrDefault(dept => dept.Id == Id);
        }
        public department editDept(int deptId, department dept)
        {
            _dbContext.Department.Attach(dept);
            _dbContext.Update(dept);
            _dbContext.SaveChanges();
            return dept;
        }
    }
}
