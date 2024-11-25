using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto.OpenWeatherDto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.OpenWeathers;

namespace ShopTARge23.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;

        public OpenWeathersController
            (
                IOpenWeatherServices openWeatherServices
            )
        {
            _openWeatherServices = openWeatherServices;
        }

        public IActionResult Index(string? city)
        {
            OpenWeatherIndexViewModel vm = new OpenWeatherIndexViewModel();
            OpenWeatherSearchViewModel search = new OpenWeatherSearchViewModel();

            ViewData["Title"] = "OpenWeather";

            if (!string.IsNullOrWhiteSpace(city))
            {
                OpenWeatherRootDto dto = new OpenWeatherRootDto
                {
                    Name = city
                };
                _openWeatherServices.OpenWeatherResult(dto);

                if (dto != null && dto.Main != null && dto.Weather != null && dto.Weather.Any())
                {
                    vm = new OpenWeatherIndexViewModel
                    {
                        Name = dto.Name,
                        Pressure = dto.Main.Pressure,
                        Humidity = dto.Main.Humidity,
                        Temp = dto.Main.Temp,
                        FeelsLike = dto.Main.FeelsLike,
                        WindSpeed = dto.Wind.Speed,
                        WeatherConditions = dto.Weather.Select(w => new WeatherConditions
                        {
                            Main = w.Main
                        }).ToList(),
                    };
                }
                else
                {
                    TempData["Error"] = "No data found while searching for the city. Please check the name of the city and try again.";
                }
            }

            return View(Tuple.Create(vm, search));
        }

        [HttpPost]
        public IActionResult CitySearch(OpenWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", new { city = model.Name });
            }

            TempData["Error"] = "Invalid input, please try again.";
            return RedirectToAction("Index");
        }
    }
}
