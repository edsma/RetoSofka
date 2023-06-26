using Microsoft.EntityFrameworkCore;
using RetoSofka.Domain.Interfaces;
using RetoSofka.Domain.Inventario;
using System.Data.SqlClient;

namespace RetoSofka.Infrastructure.Inventario
{
    public class OperationProduct : InventoryInterface
    {
        private readonly SqlConnection sqlConnection;
        private readonly ApplicationDbContext _context;

        public OperationProduct(ApplicationDbContext connection)
        {
            this._context = connection;
            //this.sqlConnection = new SqlConnection(_context.Database.GetConnectionString());

        }

        public async Task<Product> GetProductById(Guid idProduct)
        {
            return await _context.Product
                .FirstOrDefaultAsync(x=> x.idProduct.Equals(idProduct));
        }

        public async Task<List<Product>> GetAllProduct(Dtos.Common.Filters filters)
        {
            if (filters.Page == 0)
                filters.Page = 1;

            if (filters.Top == 0)
                filters.Top = 100;

            var skip = (filters.Page - 1) * filters.Top;
            return await _context.Product.Skip(skip).Take(filters.Top).ToListAsync();


        }

        public async Task AddProduct(Dtos.Inventorario.Product addProduct)
        {
            Product? product = await _context
             .Product
             .FirstOrDefaultAsync(x => x.idProduct == addProduct.idProduct);
            if (addProduct.ValidateCapactity() && product == null)
            {
                Product newProduct = new Product(addProduct.nameProduct, addProduct.inInventory, addProduct.enabled, addProduct.min, addProduct.max);
                await _context
                    .Product.AddAsync(newProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(Guid idProduct)
        {
            Product? product = await _context
                .Product
                .FirstOrDefaultAsync(x => x.idProduct == idProduct);

            if (product != null)
            {
                _context.Entry(product).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }

        }


        public async Task PutProduct(Dtos.Inventorario.Product product)
        {
            Product? productDb = await _context
                .Product
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.idProduct == product.idProduct);
            if (productDb != null && product.min >= productDb.min)
            {
                Product updateProduct = new Product(
                    product.idProduct,
                    product.nameProduct,
                    product.inInventory,
                    product.enabled,
                    product.min,
                product.max);
                _context.Entry(updateProduct).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateInventory(List<Dtos.Shop.DetailShopProduct> products)
        {
            foreach (var item in products)
            {
                Product? productDb = await _context
                .Product
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.idProduct == item.idProduct);
                if (productDb != null)
                {
                    productDb.SetInInventory(productDb.inInventory, item.quantity);
                    _context.Entry(productDb).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
