using System.ComponentModel.DataAnnotations;

namespace WeatherApi.Models
{
    public class SearchByCity
    {
        [Required(ErrorMessage ="City Name Is Empty")]
        [Display(Name ="City Name")]
        public string CityName { get; set; }
    }
}
