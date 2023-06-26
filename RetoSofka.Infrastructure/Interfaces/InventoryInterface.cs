using RetoSofka.Domain.Inventario;

namespace RetoSofka.Domain.Interfaces
{
    public interface InventoryInterface
    {
        Task<List<Product>> GetAllProduct(Dtos.Common.Filters filters);

        Task<Product> GetProductById(Guid idProduct);

        Task AddProduct(Dtos.Inventorario.Product addProduct);

        Task PutProduct(Dtos.Inventorario.Product addProduct);

        Task UpdateInventory(List<Dtos.Shop.DetailShopProduct> products);

        Task DeleteProduct(Guid idProduct);
    }
}
