using System.ComponentModel.DataAnnotations.Schema;

namespace RetoSofka.Domain.Inventario
{
    [Table(nameof(Product))]
    public class Product
    {
        public Product()
        {

        }

        public Product(string Name,
            int InInventory,
            bool Enabled,
            int Min,
            int Max)
        {
            this.nameProduct = Name;
            this.inInventory = InInventory;
            this.enabled = Enabled;
            this.min = Min;
            this.max = Max;
        }

        public Product(
        Guid idProduct,
      string Name,
      int InInventory,
      bool Enabled,
      int Min,
      int Max)
        {
            this.idProduct = idProduct;
            this.nameProduct = Name;
            this.inInventory = InInventory;
            this.enabled = Enabled;
            this.min = Min;
            this.max = Max;
        }

        public Guid idProduct { get; protected set; }

        public string nameProduct { get; protected set; }
        public int inInventory { get; protected set; }
        public bool enabled { get; protected set; }
        public int min { get; protected set; }
        public int max { get; protected set; }

        public void SetInInventory(int inInventary, int buyQuantity)
        {
            this.inInventory = inInventory - buyQuantity;
        }
    }
}
