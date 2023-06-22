using Common.Common;
using Microsoft.EntityFrameworkCore;
using RetoSofka.Domain.Inventario;
using RetoSofka.Domain.Shop;
using RetoSofka.Infrastructure.Interfaces;
using static RetoSofka.Domain.Common.Enums;

namespace RetoSofka.Infrastructure.Store
{
    public class OperationShopping : ShoppingInterface
    {
        private readonly ApplicationDbContext _context;

        public OperationShopping(ApplicationDbContext connection)
        {
            this._context = connection;
        }


        public async Task<List<Shopping>> GetHistoryShopping()
        {

            return await _context
                .Shopping
                .Include(Constants.relationBetweenDetailProduct)
                .ToListAsync();
        }

        public async Task Shopping(Dtos.Shop.Shopping shopToAdd)
        {
            bool canContineWithShop = true;
            List<Product> productsList = await _context
             .Product
             .ToListAsync();

            if (productsList.Count == 0 || !shopToAdd.Products.Any())
            {
                return;
            }
            canContineWithShop = ValidateProducts(productsList,shopToAdd);

            if (canContineWithShop)
            {
                await AddShopToTable(shopToAdd);
            }

        }

        private bool ValidateProducts(List<Product> productsList, Dtos.Shop.Shopping shopToAdd)
        {
            bool status = true;
            foreach (var item in shopToAdd.Products)
            {
                Product findProduct = productsList.FirstOrDefault(x => x.idProduct.Equals(item.idProduct));
                if (findProduct == null)
                {
                    status = false;
                    break;
                }

                if ((item.quantity > findProduct.inInventory) || (item.quantity < findProduct.min) || (item.quantity > findProduct.max))
                {
                    status = false;
                    break;
                }
            }
            return status;  
        }

        private async Task AddShopToTable(Dtos.Shop.Shopping shopToAdd)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Shopping newShopping = new Shopping((TypeCc)shopToAdd.IdType,
                    shopToAdd.Id,
                    shopToAdd.ClientName);
                    await _context
                        .Shopping.AddAsync(newShopping);
                    await _context.SaveChangesAsync();
                    Guid newId = newShopping.idShopping;
                    List<DetailShopProduct> listDetailShop = new List<DetailShopProduct>();
                    foreach (var item in shopToAdd?.Products)
                    {
                        listDetailShop.Add(new DetailShopProduct(item.idProduct.Value, newId, item.quantity));
                    }
                    await _context.AddRangeAsync(listDetailShop);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }


        }
    }
}
