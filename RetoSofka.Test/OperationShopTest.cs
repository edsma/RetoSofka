using Microsoft.EntityFrameworkCore;
using RetoSofka.Infrastructure;
using RetoSofka.Infrastructure.Inventario;
using RetoSofka.Infrastructure.Store;
using RetoSofka.Test.Mock;

namespace RetoSofka.Test
{
    public class OperationShopTest: BaseTest
    {
        public readonly OperationShopping sut;
        public OperationShopTest()
        {
            sut = new OperationShopping(_dbContext);
            _dbContext.Product.AddRange(ProductMockData.GetProducts());
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task TestGenericMethodGetAll()
        {
            var mockDataClient = ShoppingMockData.GetDetailsShippoing();
            foreach (var item in mockDataClient)
            {
                item.detailProduct.AddRange(ShoppingMockData.GetDetailsShoppingProduct());
            }
            _dbContext.Shopping.AddRange(mockDataClient);
            _dbContext.SaveChanges();
            var result = await sut.GetHistoryShopping();
            Assert.True(result.Any());
        }

        [Fact]
        public async Task TestGenericMethodElsePost()
        {
            var mockDataClient = ShoppingMockData.GetDetailsShippoingDto();
            mockDataClient.Products = new List<Dtos.Shop.DetailShopProduct>();
            mockDataClient.Products.AddRange(ShoppingMockData.GetDetailsShoppingProductDto());
            await sut.Shopping(mockDataClient);
        }

     
    }
}
