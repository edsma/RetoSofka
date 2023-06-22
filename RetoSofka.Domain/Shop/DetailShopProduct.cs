using RetoSofka.Domain.Inventario;
using System.ComponentModel.DataAnnotations.Schema;


namespace RetoSofka.Domain.Shop
{
    public class DetailShopProduct
    {
        public DetailShopProduct()
        {

        }

        public DetailShopProduct(Guid IdProduct, Guid IdShopping, int quantity)
        {
            this.idProduct = IdProduct;
            this.idShoppingRef = IdShopping;
            this.quantity = quantity;
        }

        public Guid idDetatilShopProduct { get; set; }
        public Guid idProduct { get; set; }
        public Guid idShoppingRef { get; set; }
        public int quantity { get; set; }

        [ForeignKey("idProduct")]
        public Product product { get; set; }

    }
}
