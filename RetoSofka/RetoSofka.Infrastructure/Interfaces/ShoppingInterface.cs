using RetoSofka.Domain.Shop;


namespace RetoSofka.Infrastructure.Interfaces
{
    public interface ShoppingInterface
    {
        Task<List<Shopping>> GetHistoryShopping();

        Task Shopping(Dtos.Shop.Shopping shopToAdd);
    }
}
