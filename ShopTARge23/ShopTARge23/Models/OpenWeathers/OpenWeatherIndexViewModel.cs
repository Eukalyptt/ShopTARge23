namespace ShopTARge23.Models.OpenWeathers
{
    public class OpenWeatherIndexViewModel
    {
        public string Name { get; set; }
        public double FeelsLike { get; set; }
        public double Temp {  get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public List<WeatherConditions> WeatherConditions { get; set; }
    }

    public class WeatherConditions
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
