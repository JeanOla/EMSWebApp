using EMSWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSWebApp.Data
{
    public static class SeedData
    {
        public static void SeedDafaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<department>().HasData(
               new department
               {
                   Id = 19,
                   Name = "default1"
               }
               );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id= 22,
                    Name="default1",
                    dob = DateTime.Now.AddDays(1),
                    email="defaultemail@email.com",
                    Phone="09194324567",
                    departmentId = 2
                }
               );
        }
    }
}
