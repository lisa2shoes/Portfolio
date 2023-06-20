using Newtonsoft.Json;

namespace hw14;

public class HolidaysExternalServiceProxy
{
    public static async Task<List<Holiday>> GetHolidaysAsync(int year, string countryCode)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://date.nager.at/api/v3/");

        var holidays = await httpClient.GetAsync($"PublicHolidays/{year}/{countryCode}");
        var holidaysJsonList = await holidays.Content.ReadAsStringAsync();
        var holidaysList = JsonConvert.DeserializeObject<List<Holiday>>(holidaysJsonList, new JsonSerializerSettings());

        return holidaysList;
    }
    
    public static async Task<List<CountryModel>> GetAvailableCountries()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://date.nager.at/api/v3/");

        var response = await httpClient.GetAsync($"AvailableCountries");
        var availableCountries = JsonConvert.DeserializeObject<List<CountryModel>>(
            await response.Content.ReadAsStringAsync(), new JsonSerializerSettings());

        return availableCountries;
    }
}
