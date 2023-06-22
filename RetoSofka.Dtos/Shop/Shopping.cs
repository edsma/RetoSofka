using RetoSofka.Dtos.Inventorario;
using System.ComponentModel.DataAnnotations;
using static RetoSofka.Dtos.Common.Enums;

namespace RetoSofka.Dtos.Shop
{
    public class Shopping
    {
        public Guid IdShopping { get; set; }

        [Required]
        public DateTime date { get; set; }
        [Required]
        public TypeCc IdType { get; set; }
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public List<DetailShopProduct> Products { get; set; }

    }
}
