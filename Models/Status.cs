using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string OrderStatus { get; set; }
    }
}
