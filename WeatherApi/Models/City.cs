using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WeatherApi.Models
{
    public class City
    {
        [DisplayName("City Name")]
        public string Name { get; set; }
        public float Temprature { get; set; }
        public int Humidity { get; set; }
        public int Presure { get; set; }
        public float Wind { get; set; }
        public string Weather { get; set; }
    }
}
