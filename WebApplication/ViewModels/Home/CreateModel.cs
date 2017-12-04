using System.ComponentModel.DataAnnotations;
using WebApplication.EntityModels;

namespace WebApplication.ViewModels.Home
{
    public class CreateModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
