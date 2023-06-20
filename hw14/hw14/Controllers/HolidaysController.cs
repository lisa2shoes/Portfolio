using Microsoft.AspNetCore.Mvc;

namespace hw14.Controllers
{
    [ApiController]
    [Route("holidays")]
    public class HolidayController
    {
        [HttpPost]
        [Route("get-holidays-from-body")]
        public async Task<List<Holiday>> Post([FromBody] HolidayRequest parameters)
        {
            return await HolidaysExternalServiceProxy.GetHolidaysAsync(parameters.Year, parameters.CountryCode);
        }
        
        [HttpGet("get-holidays-per-country")]
        public async Task<List<CountryInfo>> Post()
        {
            return await CountryHolidaysCounter.CountHolidaysPerCountry();
        }

        [HttpGet]
        [Route("get-holidays-duration/{year}")]
        public async Task<List<CountryHolidayInfo>> Get(int year)
        {
            return await HolidayDurationCounter.CountHolidayDurationPerCountry(year);
        }
    }
}