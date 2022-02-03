using Microsoft.AspNetCore.Mvc;
﻿using Bookmazon.Server.Data;
using Bookmazon.Shared.Models;
using Bookmazon.Shared.Dtos.Cart;
using Bookmazon.Shared.Models;
using Bookmazon.Server.Interfaces;

namespace Bookmazon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : Controller
    {
        // Privates
        private IUnitOfWork _uow;

        public CustomerOrderController(IUnitOfWork uow)
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
            _uow.Commit();
        }
        [HttpPost("CreatePositions")]
        public async void CreatePositions(List<CustomerOrderPosition> pos)
        {
            foreach (var posItem in pos)
            {
                _uow.customerOrderRepo.AddCustomerOrderPosition(posItem);
                _uow.Commit();
            }
        }




        /// <summary>
        /// This function returns a OrderState 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetState/{id}")]
        public async Task<ActionResult<CustomerOrderState>> GetState(int id)
        {
            var state = await _uow.customerOrderRepo.GetCustomerOrderState(id);
            return Ok(state);
        }

        /// <summary>
        /// This function returns a positionstate 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPositionState/{id}")]
        public async Task<ActionResult<CustomerOrderPositionState>> GetPositionState(int id)
        {
            var state = await _uow.customerOrderRepo.GetCustomerOrderPositionState(id);
            return Ok(state);
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