using Microsoft.Build.Framework;
using System.Numerics;

namespace EMSWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int departmentId { get; set; }
        public department department { get; set; }

       public Employee() { }
       public Employee(int id, string name, DateTime dob, string email, string phone, int departmentId)
        {
            this.Id = id;
            this.Name = name;
            this.dob = dob;
            this.email = email;
            this.Phone = phone;
            this.departmentId = departmentId;
        }
    }
}
