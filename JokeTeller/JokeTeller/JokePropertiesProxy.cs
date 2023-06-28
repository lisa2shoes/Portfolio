using Newtonsoft.Json;

namespace JokeTeller
{
    public class JokePropertiesProxy
    {
        public static async Task<JokeProperties> GetJokePropertiesAsync()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            var response = await httpClient.GetAsync("random_joke");
            var jokeCharacteristicsJson = await response.Content.ReadAsStringAsync();
            var jokeCharacteristics = JsonConvert.DeserializeObject<JokeProperties>(jokeCharacteristicsJson, new JsonSerializerSettings());

            return jokeCharacteristics;
        }

        public static async Task<List<JokeProperties>> GetTenJokesPropertiesAsync()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            var response = await httpClient.GetAsync("random_ten");
            var jokeCharacteristicsJson = await response.Content.ReadAsStringAsync();
            var jokeCharacteristics = JsonConvert.DeserializeObject<List<JokeProperties>>(jokeCharacteristicsJson, new JsonSerializerSettings());

            return jokeCharacteristics;
        }
    }
}
