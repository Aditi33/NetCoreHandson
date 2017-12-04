using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.EntityModels;

namespace WebApplication.Services
{
    public class SQLRestaurantDataService : IRestaurantDataService
    {
        private WebApplicationDbContext dbContext;

        public SQLRestaurantDataService(WebApplicationDbContext webApplicationDbContext)
        {
            this.dbContext = webApplicationDbContext;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            dbContext.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return dbContext.Restaurants.OrderBy(r => r.Name);
        }
    }
}
