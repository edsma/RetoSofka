using System.ComponentModel.DataAnnotations;

namespace RetoSofka.Dtos.Inventorario
{
    public class Product
    {
        public Guid? idProduct { get; set; }

        [Required]
        public string nameProduct { get; set; }
        [Required]
        public int inInventory { get; set; }
        [Required]
        public bool enabled { get; set; }

        [Required]
        public int min { get; set; }
        [Required]
        public int max { get; set; }

        public bool ValidateCapactity()
        {
            return min < max;
        }
    }
}
