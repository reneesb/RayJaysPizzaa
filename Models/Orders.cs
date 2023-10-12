using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public Customers Customer { get; set; }
        public Status Status { get; set; }
        public Employees Employee { get; set; }
        public PaymentType PaymentType { get; set; }
        public Ratings Rating { get; set; }
        public int Tip { get; set; }
        public int Total { get; set; }
    }
}
