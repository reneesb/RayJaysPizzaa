using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }
       
        public List<Orders> Order { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }

    }
}
