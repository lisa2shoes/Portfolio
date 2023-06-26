using Microsoft.AspNetCore.Mvc;

namespace GenderGuesser.Controllers
{
    [ApiController]
    [Route("genderguesser")]
    public class GenderGuesserController
    {
        [HttpPost]
        [Route("guess-gender-by-name/{name}")]
        public async Task<GuessedGender> Post(string name)
        {
            return await GenderGuesser.GuessGenderByName(name);
        }
    }
}