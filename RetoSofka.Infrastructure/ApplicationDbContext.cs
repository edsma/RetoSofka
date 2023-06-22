using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RetoSofka.Domain.Inventario;
using RetoSofka.Domain.Shop;

namespace RetoSofka.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Product> Product { get; set; }
        public DbSet<Shopping> Shopping { get; set; }
        public DbSet<DetailShopProduct> DetailShopProduct { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Product>()
                .HasKey(ci => new
                {
                    ci.idProduct
                });
            modelBuilder
           .Entity<Shopping>()
           .HasKey(ci => new
           {
               ci.idShopping
           });

            modelBuilder
       .Entity<DetailShopProduct>()
       .HasKey(ci => new
       {
           ci.idDetatilShopProduct
       });
        }

    }
}
