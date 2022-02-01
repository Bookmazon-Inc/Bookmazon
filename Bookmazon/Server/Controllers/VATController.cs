using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces;
using Bookmazon.Shared.Dtos.VAT;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VATController : Controller
    {
        // Privates
        private IUnitOfWork _uow;

        public VATController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// This Method retuns all VATs that are in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VATDto>>> Index()
        {
            var VATs = await _uow.BookRepo.GetAllVATs();
            return Ok(VATs.Select(v => v.ToVATDto()));
        }
    }
}
