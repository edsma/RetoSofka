using RetoSofka.Domain.Shop;
using static RetoSofka.Domain.Common.Enums;

namespace RetoSofka.Test.Mock
{
    public class ShoppingMockData
    {
        public static List<Shopping> GetDetailsShippoing()
        {
            return new List<Shopping>
            {
                new Shopping(TypeCc.CC,123457,"Ed"),
                new Shopping(TypeCc.TA,123257,"Perenito perez"),
                new Shopping(TypeCc.CC,123157,"Kaori"),
                new Shopping(TypeCc.CC,123957,"Cloud Strife"),
                new Shopping(TypeCc.TA,123657,"Alguien"),
            };
        }

        public static Dtos.Shop.Shopping GetDetailsShippoingDto()
        {
            return new Dtos.Shop.Shopping
            {
                IdType = Dtos.Common.Enums.TypeCc.CC,
                Id = 123457,
                ClientName = "Ed"
            };

        }

        internal static List<DetailShopProduct> GetDetailsShoppingProduct()
        {
            return new List<DetailShopProduct>
            {
                new DetailShopProduct
                {
                    idDetatilShopProduct = Guid.NewGuid(),
                    idProduct= Guid.NewGuid(),
                    idShoppingRef= Guid.NewGuid(),
                    quantity= 1,
                    product =  ProductMockData.GetOneProduct()
                }
            };
        }

        internal static List<Dtos.Shop.DetailShopProduct> GetDetailsShoppingProductDto()
        {
            return new List<Dtos.Shop.DetailShopProduct>
            {
                new Dtos.Shop.DetailShopProduct
                {
                    idDetatilShopProduct = Guid.NewGuid(),
                    idProduct= Guid.NewGuid(),
                    quantity= 1,
                    product =  ProductMockData.GetOneProductDto()
                }
            };
        }

    }
}
