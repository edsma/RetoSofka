using RetoSofka.Domain.Inventario;

namespace RetoSofka.Test.Mock
{
    public class ProductMockData
    {

        
        public static Guid GetId()
        {
            return new Guid("8DF4981F-DBED-4869-CF30-08DB72855E05");
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product(new Guid("8DF4981F-DBED-4869-CF30-08DB72855E05"),"Prueba 1",100,true,1,100),
                new Product(Guid.NewGuid(),"Prueba 2",50,true,30,1),
                new Product(Guid.NewGuid(),"Prueba 3",200,true,10,1),
                new Product(Guid.NewGuid(),"Prueba 4",800,true,200,1),
                new Product(Guid.NewGuid(),"Prueba 5",20,false,50,1),
            };
        }

        public static Product GetOneProduct()
        {
            return
                new Product(Guid.NewGuid(), "Pruebas", 100, true, 1, 100);
        }

        public static Dtos.Inventorario.Product GetOneProductDto()
        {
            return new Dtos.Inventorario.Product
            {
                idProduct = Guid.NewGuid(),
                nameProduct = "Pruebas",
                inInventory = 100,
                enabled = true,
                min = 1,
                max = 100
            };
        }



    }
}
