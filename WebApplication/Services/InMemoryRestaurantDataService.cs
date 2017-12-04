using System.Collections.Generic;
using System.Linq;
using WebApplication.EntityModels;

namespace WebApplication.Services
{
    public class InMemoryRestaurantDataService : IRestaurantDataService
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantDataService()
        {
            this.restaurants = new List<Restaurant>
            {
                new Restaurant{Id = 1,Name = "Pizza Hut"},
                new Restaurant{Id = 2,Name = "Talk About"},
                new Restaurant{Id = 3,Name = "Cafe Coffee Day"}
            };
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r=>r.Id)+1;
            restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return restaurants;
        }
    }
}
