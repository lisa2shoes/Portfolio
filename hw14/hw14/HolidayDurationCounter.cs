namespace hw14
{
    public class HolidayDurationCounter
    {
        public static async Task<List<CountryHolidayInfo>> CountHolidayDurationPerCountry(int year)
        {
            var countries = await HolidaysExternalServiceProxy.GetAvailableCountries();
            var countryHolidaysInfos = new List<CountryHolidayInfo>();
            foreach (var country in countries)
            {
                var holidaysInfos = new Dictionary<string, int>(); //пустой список объектов HolidayInfo (Name, Duration)
                var holidaysList = await HolidaysExternalServiceProxy.GetHolidaysAsync(year, country.CountryCode); // список праздников по заданной стране и заданному году (Date, Name)

                foreach (var holiday in holidaysList)
                {
                    if (holidaysInfos.ContainsKey(holiday.Name))
                    {
                        var duration = holidaysInfos[holiday.Name];
                        holidaysInfos[holiday.Name] = ++duration;
                    }
                    else
                    {
                        holidaysInfos[holiday.Name] = 1;
                    }
                }

                var longestHoliday = holidaysInfos.Select(holidayInfo => new HolidayInfo
                {
                    Duration = holidayInfo.Value,
                    Name = holidayInfo.Key
                }).OrderByDescending(x => x.Duration).ToList().FirstOrDefault();

                countryHolidaysInfos.Add(new CountryHolidayInfo
                {
                    CountryName = country.Name,
                    HolidayName = longestHoliday.Name,
                    Duration = longestHoliday.Duration,
                });
            }

            return countryHolidaysInfos.OrderByDescending(x => x.Duration).ToList();

        }
    }
}
