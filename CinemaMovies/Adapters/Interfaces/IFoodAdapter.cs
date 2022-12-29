using CinemaMovies.DTO;
using CinemaMovies.Models;

namespace CinemaMovies.Adapters.Interfaces
{
    public interface IFoodAdapter
    {
        GetFoodDTO Bind(Food food);
        BasketItem Bind(AddFoodDTO addFood);
    }
}