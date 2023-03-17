using EMSWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EMSWebApp.Data
{
    public class EmsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EMSDB;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
           .HasOne<department>(s => s.department)
           .WithMany(g => g.Employees)
           .HasForeignKey(s => s.departmentId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<department> Department { get; set; }

    }
}
