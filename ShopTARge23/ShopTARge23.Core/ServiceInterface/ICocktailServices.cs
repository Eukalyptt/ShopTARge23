using ShopTARge23.Core.Dto.CocktailDto;



namespace ShopTARge23.Core.ServiceInterface
{
    public interface ICocktailServices
    {
        Task<CocktailResultDto> GetCocktails(CocktailResultDto dto);
    }
}