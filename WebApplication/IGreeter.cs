using Microsoft.Extensions.Configuration;

namespace WebApplication
{
    public interface IGreeter
    {
        string GetWelcomeMessage();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetWelcomeMessage()
        {
            return _configuration["Greeting"];
        }
    }
}