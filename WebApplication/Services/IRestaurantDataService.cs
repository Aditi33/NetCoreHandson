using System.Collections.Generic;
using WebApplication.EntityModels;

namespace WebApplication.Services
{
    public interface IRestaurantDataService
    {
        IEnumerable<Restaurant> GetRestaurants();

        Restaurant Get(int id);

        Restaurant Add(Restaurant restaurant);
    }
}
