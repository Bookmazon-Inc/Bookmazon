using Bookmazon.Shared.Models;
using Bookmazon.Shared.Dtos.Publisher;
using Microsoft.AspNetCore.Mvc;
using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces;

namespace Bookmazon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : Controller
    {
        // Privates
        private IUnitOfWork _uow;

        public PublisherController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// This returns all Publishers that are in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> Index()
        {
            var Publishers = await _uow.BookRepo.GetAllPublisher();
            return Ok(Publishers.Select(p => p.ToPublisherDto()));
        }
    }
}
