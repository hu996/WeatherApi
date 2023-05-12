using WeatherApi.OpenWeatherMaps_Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WeatherApi.Repository
{
    public class WeatherRepository:IWeatherRepository
    {
       

        WeatherResponse IWeatherRepository.GetForCast(string City)
        {
            string App_Id = Configuration.Values.Open_Weather_App_ID;
            var client=new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={City}&units=metric&appid={App_Id}");
           
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content=JsonConvert.DeserializeObject<JToken>(response.Content);
                return content?.ToObject<WeatherResponse>();
            }
            return null;
        }
    }
}
