namespace hw14;

public class CountryHolidaysCounter
{
    public static async Task<List<CountryInfo>> CountHolidaysPerCountry()
    {
        var countries = await HolidaysExternalServiceProxy.GetAvailableCountries(); //список объектов CountryModel (Name, CountryCode)
        var countryInfos = new List<CountryInfo>(); //пустой список объектов CountryInfo (Name, HolidaysCount)
        foreach (var country in countries) // для каждого объекта CountryModel
        {
            var countryHolidays = await HolidaysExternalServiceProxy.GetHolidaysAsync(2023, country.CountryCode); // вывести список объектов Holiday (Date, Name)
            countryInfos.Add(new CountryInfo // добавить объект в countryInfos
            {
                Name = country.Name,
                HolidaysCount = countryHolidays.Count // метод подсчета количества
            });
        }

        return countryInfos.OrderByDescending(x => x.HolidaysCount).ToList();
    }
}