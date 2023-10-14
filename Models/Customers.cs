using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Orders> Orders { get; set; }


    }
}
