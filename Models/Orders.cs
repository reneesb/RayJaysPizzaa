using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public int RatingId { get; set; }
        public Ratings Rating { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        
        public int Tip { get; set; }
        public int Total { get; set; }
    }
}
