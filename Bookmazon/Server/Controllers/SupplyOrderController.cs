using Bookmazon.Server.Data;
using Bookmazon.Shared.Dtos;
using Bookmazon.Shared.Dtos.SupplyOrder;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{
    public class SupplyOrderController : Controller
    {
        // Variables
        private UnitOfWork _uow;

        private SupplyOrderController(UnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Returns all SupplyOrders from the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<SupplyOrderDto>>> Index()
        {
            var so = await _uow.supplyOrderRepo.GetAllSupplyOrders(null);
            return Ok(so.Select(x => x.ToSupplyOrderDto()));
        }

        /// <summary>
        /// Returns all open SupplyOrders
        /// </summary>
        /// <returns></returns>
        [HttpGet("OpenSupplyOrders")]
        public async Task<ActionResult<List<SupplyOrderDto>>> GetOpenOrders()
        {
            var so = await _uow.supplyOrderRepo.GetOpenSupplyOrders();
            return Ok(so.Select(x => x.ToSupplyOrderDto()));
        }

        /// <summary>
        /// Returns a definied amount of SupplyOrders ordered by date descending
        /// </summary>
        /// <param name="amount">The amount of wanted Orders (default = 5)</param>
        /// <returns></returns>
        [HttpGet("LastSupplyOrders")]
        public async Task<ActionResult<List<SupplyOrderDto>>> GetLastXOrders(int amount = 5)
        {
            var so = await _uow.supplyOrderRepo.GetLastXSupplyOrders(amount);
            return Ok(so.Select(x => x.ToSupplyOrderDto()));
        }
    }
}
