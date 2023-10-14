using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UID { get; set; }
    }
}
