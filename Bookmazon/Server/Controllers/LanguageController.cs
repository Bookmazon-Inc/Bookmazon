using Bookmazon.Server.Data;
using Bookmazon.Shared.Models;
using Bookmazon.Shared.Dtos.Language;
using Microsoft.AspNetCore.Mvc;
using Bookmazon.Server.Interfaces;

namespace Bookmazon.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : Controller
    {
        // Privates
        private IUnitOfWork _uow;

        public LanguageController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Returns all Languages that are in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> Index()
        {
            var Languages = await _uow.BookRepo.GetAllLanguages();
            return Ok(Languages.Select(l => l.ToLanguageDto()));
        }
    }
}
