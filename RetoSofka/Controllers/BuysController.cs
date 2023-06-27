using Common.Common;
using Microsoft.AspNetCore.Mvc;
using RetoSofka.Aplication.Services;
using RetoSofka.Domain.Interfaces;
using RetoSofka.Dtos.Shop;
using RetoSofka.Infrastructure;
using RetoSofka.Infrastructure.Interfaces;
using RetoSofka.Infrastructure.Inventario;
using RetoSofka.Infrastructure.Store;

namespace RetoSofka.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuysController : ControllerBase
    {
        private readonly ShoppingInterface shoppingProduct;
        private readonly InventoryInterface operationProduct;
        public BuysController(ApplicationDbContext con)
        {

            this.shoppingProduct = new OperationShopping(con);
            this.operationProduct = new OperationProduct(con);
        }

        /// <summary>
        /// Consulta el historial de compras
        /// </summary>
        /// <returns>Listado de compras realizadas.</returns>
        [HttpGet("GetHistory")]
        public async Task<ActionResult<List<Shopping>>> GetAllProducts()
        {
            var result = await this.shoppingProduct.GetHistoryShopping();
            return Ok(result);
        }

        /// <summary>
        /// Registra la compra en base de datos
        /// </summary>
        /// <param name="itemsForShopping">Clase con los campos requeridos para ingresar la compra</param>
        [HttpPost("BuyItems")]
        public async Task<ActionResult> BuyItems(Shopping itemsForShopping)
        {
            if (itemsForShopping.Products.Count > 0)
            {
                await this.shoppingProduct.Shopping(itemsForShopping);
                await this.operationProduct.UpdateInventory(itemsForShopping?.Products);

                return Ok();
            }
            else
            {
                return BadRequest(new ShoppingException(Constants.messageErrorsNoItems));
            }
           
        }
    }
}
