using Nancy.Json;
using ShopTARge23.Core.Dto.OpenWeatherDto;
using ShopTARge23.Core.ServiceInterface;
using System.Net;

namespace ShopTARge23.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherRootDto> OpenWeatherResult(OpenWeatherRootDto dto)
        {
            string openweatherApiKey = "5efbce10ea77a80dfa38d1b4e4928a56";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.Name}&appid={openweatherApiKey}&units=metric";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    Console.WriteLine("API Response: " + json);

                    OpenWeatherRootDto openWeatherResult
                        = new JavaScriptSerializer().Deserialize<OpenWeatherRootDto>(json);

                    dto.Name = openWeatherResult.Name;
                    dto.Wind = openWeatherResult.Wind;
                    dto.Weather = openWeatherResult.Weather;
                    dto.Main = openWeatherResult.Main;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting weather data: {ex.Message}");
                throw;
            }

            return dto;
        }
    }
}
