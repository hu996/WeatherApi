using System.Collections.Generic;
using System.Security.Policy;

namespace WeatherApi.OpenWeatherMaps_Model
{
    public class WeatherResponse
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string Base { get; set; }
        public Main main { get; set; }
        public int Visibality { get; set; }
        public Wind Wind { get; set; }
        public Cloud Cloud { get; set; }
        public int DT { get; set; }
        public Sys Sys { get; set; } 
        public int TimeZone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }    
        public int COD { get; set; }
        public DailyTemprture dailyTemprture { get; set; }
    }
}
