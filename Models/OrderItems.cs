namespace RayJaysPizza.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public Orders Order { get; set; }
        public Items Item { get; set; }
        public int Count { get; set; }

    }
}
