using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/")]
    public class WelcomeController : Controller
    {
        private readonly WelcomeMessage _message;

        public WelcomeController(WelcomeMessage message)
        {
            _message = message;
        }

        [HttpGet]
        public string SayHello()
        {
            return _message.Message;
        }
    }
}