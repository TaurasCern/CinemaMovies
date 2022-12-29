using CinemaMovies.Adapters.Interfaces;
using CinemaMovies.DTO;
using CinemaMovies.Models;
using CinemaMovies.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodAdapter _foodAdapter;

        [HttpGet]
        public ActionResult<List<GetFoodDTO>> GetAll()
        {
            var foods = _foodRepository.GetAll();
            var foodDTOs = foods.Select(f => _foodAdapter.Bind(f)).ToList();
            return Ok(foodDTOs);
        }

        [HttpPut("toBasket")]
        public IActionResult AddFoodToBasket(AddFoodDTO addFood)
        {
            var item = _foodAdapter.Bind(addFood);
            var basket = _foodAdapter.Bind(addFood, item);
            _foodRepository.Update(basket);
            return Ok();
        }
    }
}
