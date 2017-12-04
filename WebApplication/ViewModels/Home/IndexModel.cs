using System.Collections.Generic;
using WebApplication.EntityModels;

namespace WebApplication.ViewModels.Home
{
    public class IndexModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public string CurrentMessage { get; set; }
    }
}
