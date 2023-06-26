using Microsoft.AspNetCore.Mvc;
using RetoSofka.Domain.Interfaces;
using RetoSofka.Dtos.Common;
using RetoSofka.Dtos.Inventorario;
using RetoSofka.Infrastructure;
using RetoSofka.Infrastructure.Inventario;

namespace RetoSofka.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly InventoryInterface operationProduct;

        public ProductsController(ApplicationDbContext con)
        {

            this.operationProduct = new OperationProduct(con);
        }

        /// <summary>
        /// Consulta los registrados con paginación
        /// </summary>
        /// <param name="filters">Clase con los parametros de paginación</param>
        /// <returns></returns>
        [HttpPost("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts([FromBody] Filters filters)
        {
            return Ok(await this.operationProduct.GetAllProduct(filters));
        }


        /// <summary>
        /// Consulta un producto por su respectivo Id
        /// </summary>
        /// <param name="idProduct">Id del producto</param>
        /// <returns>Objeto producto con sus propiedades</returns>
        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById( Guid idProduct)
        {
            return Ok(await this.operationProduct.GetProductById(idProduct));
        }

        /// <summary>
        /// Ingresa el producto a base de datos
        /// </summary>
        /// <param name="addProduct">Clase con las propiedades requeridas para ingresar el producto</param>
        /// <returns></returns>
        [HttpPost("AddProduct")]
        public async Task<ActionResult> PostProduct([FromBody] Product addProduct)
        {
            await this.operationProduct.AddProduct(addProduct);
            return Ok();
        }

        /// <summary>
        /// Actualiza la información de un producto
        /// </summary>
        /// <param name="addProduct">Clase con las propiedades requeridas para actualizar el producto</param>
        /// <returns></returns>
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> PutProduct([FromBody] Product addProduct)
        {
            await this.operationProduct.PutProduct(addProduct);
            return Ok();
        }


        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="idProduct"></param>
        /// <returns></returns>
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(Guid idProduct)
        {
            await this.operationProduct.DeleteProduct(idProduct);
            return Ok();
        }

    }
}
