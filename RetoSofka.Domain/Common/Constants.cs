namespace Common.Common
{
    public class Constants
    {
        public const string defaultConnection = "DefaultConnection";
        public const string selectAll = "select * from";
        public const string orderByQuery = "ORDER BY";
        public const string constFinalPartQuery = " * from";
        public const string constLimitQuery = "LIMIT";
        public const string constOfsetQuery = " OFFSET";
        public const string relationBetweenDetailProduct = "detailProduct.product";
        public const string messageErrors = "No se puede realizar la compra la cantidad es inferior a la cantidad minima requerida";
        public const string messageErrorsNoItems = "No tiene items agregados para comprar";
        public const string messageErrorsNeedMoreItems = "Debe existir una mayor cantidad en el campo maximo";
    }
}