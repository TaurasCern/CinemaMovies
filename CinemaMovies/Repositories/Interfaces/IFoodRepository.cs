using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        List<Food> GetAll();
        void Create(BasketItem item);
    }
}