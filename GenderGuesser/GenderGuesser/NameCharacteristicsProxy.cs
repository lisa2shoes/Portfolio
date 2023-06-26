using Newtonsoft.Json;

namespace GenderGuesser
{
    public class NameCharacteristicsProxy
    {
        public static async Task<NameCharacteristics> GetNameCharacteristicsAsync(string name)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://api.genderize.io/");
            var response = await httpClient.GetAsync($"?name={name}");
            var nameCharacterisctics = JsonConvert.DeserializeObject<NameCharacteristics>(
            await response.Content.ReadAsStringAsync(), new JsonSerializerSettings());

            return nameCharacterisctics;
        }
    }
}
