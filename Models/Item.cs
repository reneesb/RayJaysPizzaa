using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        
    }
}
