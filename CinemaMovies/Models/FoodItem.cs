
namespace CinemaMovies.Models
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<BasketFood> BasketFoods { get; set; }
    }
}
