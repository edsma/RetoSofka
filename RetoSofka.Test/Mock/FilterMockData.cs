using RetoSofka.Dtos.Common;

namespace RetoSofka.Test.Mock
{
    public class FilterMockData
    {
        public static Filters GetFilter()
        {
            return new Filters
            {
                Page = 1,
                RowToOrder = "nameProduct",
                Top = 10
            };
        }

        public static Filters GetFilterWithoutRow()
        {
            return new Filters
            {
                Page = 1,
                RowToOrder = string.Empty,
                Top = 10
            };
        }
    }
}
