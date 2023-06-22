using System.ComponentModel.DataAnnotations.Schema;
using static RetoSofka.Domain.Common.Enums;

namespace RetoSofka.Domain.Shop
{
    [Table(nameof(Shopping))]
    public class Shopping
    {

        public Shopping()
        {
        }

        public Shopping(TypeCc Type,
            int Id,
            string ClientName
            )
        {
            this.idType = Type;
            this.clientName = ClientName;
            this.date = DateTime.Now;
            this.id = Id;
            this.detailProduct = new List<DetailShopProduct>();
        }

        public Guid idShopping { get; protected set; }

        public DateTime date { get; protected set; }

        public TypeCc idType { get; protected set; }
        public int id { get; protected set; }
        public string? clientName { get; protected set; }

        [ForeignKey("idShoppingRef")]
        public List<DetailShopProduct> detailProduct { get; protected set; }
    }
}
