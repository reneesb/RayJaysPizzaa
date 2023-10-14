using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza.Models
{
    public class Ratings
    {
        [Key]
        public int RatingId { get; set; }
        public int StarRating { get; set; }
    }
}
