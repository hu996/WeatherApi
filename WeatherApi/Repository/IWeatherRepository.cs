using WeatherApi.OpenWeatherMaps_Model;

namespace WeatherApi.Repository
{
    public interface IWeatherRepository
    {
        WeatherResponse GetForCast(string City);
    }
}
