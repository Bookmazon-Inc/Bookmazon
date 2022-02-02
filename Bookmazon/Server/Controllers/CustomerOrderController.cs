using Microsoft.AspNetCore.Mvc;
﻿using Bookmazon.Server.Data;
using Bookmazon.Shared.Dtos.Cart;
using Bookmazon.Shared.Models;

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
        public async void CreateOrder(CustomerOrder ord)
        {
            _uow.customerOrderRepo.AddCustomerOrder(ord);
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