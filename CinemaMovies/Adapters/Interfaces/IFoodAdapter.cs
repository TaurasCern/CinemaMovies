using CinemaMovies.DTO;
using CinemaMovies.Models;

namespace CinemaMovies.Adapters.Interfaces
{
    public interface IFoodAdapter
    {
        GetFoodDTO Bind(FoodItem food);
        BasketFood Bind(AddFoodDTO addFood);
        Basket Bind(AddFoodDTO addFood, BasketFood food);
    }
}