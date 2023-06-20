namespace hw14;

public class CountryHolidaysCounter
{
    public static async Task<List<CountryInfo>> CountHolidaysPerCountry()
    {
        var countries = await HolidaysExternalServiceProxy.GetAvailableCountries(); //������ �������� CountryModel (Name, CountryCode)
        var countryInfos = new List<CountryInfo>(); //������ ������ �������� CountryInfo (Name, HolidaysCount)
        foreach (var country in countries) // ��� ������� ������� CountryModel
        {
            var countryHolidays = await HolidaysExternalServiceProxy.GetHolidaysAsync(2023, country.CountryCode); // ������� ������ �������� Holiday (Date, Name)
            countryInfos.Add(new CountryInfo // �������� ������ � countryInfos
            {
                Name = country.Name,
                HolidaysCount = countryHolidays.Count // ����� �������� ����������
            });
        }

        return countryInfos.OrderByDescending(x => x.HolidaysCount).ToList();
    }
}