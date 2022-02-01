using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces;
using Bookmazon.Shared.Dtos.Genre;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        // Privates
        private IUnitOfWork _uow;

        public GenreController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Gets al Genres in the DataBase
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> Index()
        {
            var Genres = await _uow.BookRepo.GetAllGenre();
            return Ok(Genres.Select(g => g.ToGenreDto()));
        }
    }
}
