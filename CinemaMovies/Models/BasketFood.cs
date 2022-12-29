namespace CinemaMovies.Models
{
    public class BasketFood
    {
        public int BasketFoodId { get; set; }
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
