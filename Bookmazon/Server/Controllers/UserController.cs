using Bookmazon.Server.Interfaces;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUnitOfWork _uow;

        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// This function returns a user from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var usr = await _uow.UserRepo.GetUser(id);
            return Ok(usr);
        }



        /// <summary>
        /// This returns all Users from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Index()
        {
            var usr = await _uow.UserRepo.GetAllUsers();
            return Ok(usr);
        }
    }
}
