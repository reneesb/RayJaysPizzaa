using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string PaymentName { get; set; }
    }
}
