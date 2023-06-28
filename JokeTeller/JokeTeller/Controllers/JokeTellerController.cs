using Microsoft.AspNetCore.Mvc;

namespace JokeTeller.Controllers
{
    [ApiController]
    [Route("joker")]
    public class JokeTellerController
    {
        [HttpGet]
        [Route("tell-a-joke")]

        public async Task<Joke> Get()
        {
            return await JokeTeller.TellAJoke();
        }

        [HttpPost]
        [Route("tell-10-jokes")]

        public async Task<List<Joke>> Post()
        {
            return await JokeTeller.TellTenJokes();
        }
    }
}