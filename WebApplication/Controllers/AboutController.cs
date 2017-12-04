using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("[Controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+1-9850052891";
        }

        [Route("[Action]")]
        public string Address()
        {
            return "ISH";
        }
    }
}
