using Microsoft.AspNetCore.Mvc;
using System;
using WeatherApi.Models;
using WeatherApi.OpenWeatherMaps_Model;
using WeatherApi.Repository;

namespace WeatherApi.Controllers
{
    public class WeatherForcastController : Controller
    {
        private readonly IWeatherRepository _weather;
        public WeatherForcastController(IWeatherRepository weather)
        {
            _weather = weather;
        }
        [HttpGet]
        public IActionResult SearchByCity()
        {
            var ViewModel = new SearchByCity();
            return View(ViewModel);
        }
        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", new { City = model.CityName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherresponse = _weather.GetForCast(city);
            City viewmodel = new City();
            //WeatherVieModel viewmodel = new WeatherVieModel();
            if (weatherresponse != null)
            {
                viewmodel.Name = weatherresponse.Name;
                viewmodel.Temprature = weatherresponse.main.Temp;
                viewmodel.Humidity = weatherresponse.main.Humidity;
                viewmodel.Presure = weatherresponse.main.Pressure;
                viewmodel.Weather = weatherresponse.weather[0].Main;
                viewmodel.Wind = weatherresponse.Wind.Speed;

            }
            ViewBag.waetherdate = DateTime.Now.ToString("dd MMMM yyyy");
            return View(viewmodel);
        }
        [HttpGet]
        public IActionResult DailyTemp(string city)
        {
            WeatherResponse weatherResponse = _weather.GetForCast(city);
            DailyTemprture daytem = new DailyTemprture();
            if (weatherResponse != null)
            {
                daytem.Day = weatherResponse.dailyTemprture.Day;
                daytem.DailyMax = weatherResponse.dailyTemprture.DailyMax;
                daytem.DailyMin = weatherResponse.dailyTemprture.DailyMin;
                daytem.Night = weatherResponse.dailyTemprture.Night;
                daytem.Morning = weatherResponse.dailyTemprture.Morning;
                daytem.Evening = weatherResponse.dailyTemprture.Evening;
            }
            return View(daytem);
        }
    }
}
