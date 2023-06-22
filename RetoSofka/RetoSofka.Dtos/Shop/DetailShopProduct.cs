using RetoSofka.Dtos.Inventorario;
using System.ComponentModel.DataAnnotations;

namespace RetoSofka.Dtos.Shop
{
    public class DetailShopProduct
    {
        public Guid? idDetatilShopProduct { get; set; }
        [Required]
        public Guid? idProduct { get; set; }
        [Required]
        public int quantity { get; set; }

        public Product? product { get; set; }
    }
}
