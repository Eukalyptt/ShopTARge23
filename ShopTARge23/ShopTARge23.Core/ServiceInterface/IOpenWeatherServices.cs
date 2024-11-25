using ShopTARge23.Core.Dto.OpenWeatherDto;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        Task<OpenWeatherRootDto> OpenWeatherResult(OpenWeatherRootDto dto);
    }
}
