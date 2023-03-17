using System.Numerics;

namespace EMSWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime dob { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public int departmentId { get; set; }
        public department department { get; set; }

        public Employee() { }

    }
}
