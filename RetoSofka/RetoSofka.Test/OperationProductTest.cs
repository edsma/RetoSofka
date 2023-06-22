using Microsoft.EntityFrameworkCore;
using RetoSofka.Infrastructure;
using RetoSofka.Infrastructure.Inventario;
using RetoSofka.Test.Mock;

namespace RetoSofka.Test
{
    public class OperationProductTest : BaseTest
    {

        [Fact]
        public async Task TestGenericMethodGetAll()
        {
            _dbContext.Product.AddRange(ProductMockData.GetProducts());
            _dbContext.SaveChanges();
            var result = await this.operationProduct.GetAllProduct(FilterMockData.GetFilter());
            Assert.True(result.Any());
        }

        [Fact]
        public async Task TestGenericMethodGetAllByWithOut()
        {
            _dbContext.Product.AddRange(ProductMockData.GetProducts());
            _dbContext.SaveChanges();
            var result = await this.operationProduct.GetAllProduct(FilterMockData.GetFilterWithoutRow());
            Assert.True(result.Any());
        }



        [Fact]
        public async Task TestGenericMethodDeleteInformation()
        {
            _dbContext.Product.AddRange(ProductMockData.GetProducts());
            _dbContext.SaveChanges();
            var newData = ProductMockData.GetId();

            await this.operationProduct.DeleteProduct(newData);

        }

    

        [Fact]
        public async Task TestGenericMethodPostAdd()
        {
            var mockDataClient = ProductMockData.GetOneProductDto();
            await this.operationProduct.AddProduct(mockDataClient);
        }

      
    }
}