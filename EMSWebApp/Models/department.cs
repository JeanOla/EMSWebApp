using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;

namespace EMSWebApp.Models
{
    public class department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }

        public department() { } 
        public department( int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
