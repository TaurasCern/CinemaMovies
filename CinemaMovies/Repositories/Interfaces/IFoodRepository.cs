using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        List<FoodItem> GetAll();
        void Update(Basket basket);
    }
}