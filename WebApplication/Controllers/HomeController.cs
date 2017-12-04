using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.EntityModels;
using WebApplication.Services;
using WebApplication.ViewModels.Home;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantDataService restaurantDataService;
        private readonly IGreeter greeter;

        public HomeController(IRestaurantDataService restaurantDataService, IGreeter greeter)
        {
            this.restaurantDataService = restaurantDataService;
            this.greeter = greeter;
        }

        public IActionResult Index()

        {
            #region Retun Conent

            //return Content("This is response from HomeController!");

            #endregion

            #region MyRegion

            //var restaurant = new Restaurant
            //{
            //    Id = 1,
            //    Name = "Pizza Hut"
            //};

            //return new ObjectResult(restaurant);

            #endregion

            #region Return Restaurant

            //var restaurant = new Restaurant
            //{
            //    Id = 1,
            //    Name = "Pizza Hut"
            //};

            //return View(restaurant);

            #endregion

            #region Return Restaurants

            ////var restaurants = restaurantDataService.GetRestaurants();
            ////return View(restaurants);

            #endregion

            var indexModel = new IndexModel
            {
                CurrentMessage = greeter.GetWelcomeMessage(),
                Restaurants = restaurantDataService.GetRestaurants()
            };

            return View(indexModel);
        }

        public IActionResult Details(int id)
        {
            //return Content(id.ToString());

            var restaurant = restaurantDataService.Get(id);
            if (restaurant == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken] //Check form require token send and posted
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateModel createModel)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant
                {
                    Name = createModel.Name,
                    Cuisine = createModel.Cuisine
                };

                newRestaurant = restaurantDataService.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new {id = newRestaurant.Id});
            }
            else
            {
                return View();
            }
        }
    }
}
