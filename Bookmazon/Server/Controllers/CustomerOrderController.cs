using Bookmazon.Server.Data;
using Bookmazon.Shared.Dtos.Cart;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{
    [Route("api/[controller]")]
    public class CustomerOrderController : Controller
    {
        // Privates
        private UnitOfWork _uow;

        public CustomerOrderController(UnitOfWork uow)
        {
            _uow = uow;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerOrder"></param>
        [HttpPost("CreateOrder")]
        public async void CreateOrder(IList<CartItemDto> cartItems)
        {
            List<CustomerOrderPosition> custOrdPos = new List<CustomerOrderPosition>();
            CustomerOrder cusOrd = new CustomerOrder
            {

            };

            foreach (CartItemDto cartItem in cartItems)
            {
                custOrdPos.Add(new CustomerOrderPosition 
                {
                    
                });
            }
        }










        /// <summary>
        /// Returns all CustomerOrders in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerOrder>>> Index()
        {
            var cuo = await _uow.customerOrderRepo.GetAllCustomerOrders(null);
            return Ok(cuo);
        }
    }
}
