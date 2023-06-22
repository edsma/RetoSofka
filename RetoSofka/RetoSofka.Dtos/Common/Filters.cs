namespace RetoSofka.Dtos.Common
{
    public class Filters
    {
        public int Top { get; set; }
        public int Page { get; set; }

        private string rowToOrder { get; set; }

        public string RowToOrder
        {
            get
            {
                return rowToOrder;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    rowToOrder = nameof(Dtos.Inventorario.Product.nameProduct);
                }
                else
                {
                    rowToOrder = value;
                }
            }
        }
    }
}
