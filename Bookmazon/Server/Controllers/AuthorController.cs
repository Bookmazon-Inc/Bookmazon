using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces;
using Bookmazon.Shared.Dtos.Author;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        // Private
        private IUnitOfWork _uow;

        public AuthorController(IUnitOfWork uow)
        {
            _uow = uow;
        }



        [HttpGet("GetAuthor/{AuthorId}")]
        public async Task<ActionResult<Author>> GetAuthor(int AuthorId)
        {
            var author = await _uow.BookRepo.GetAuthor(AuthorId);
            return Ok(author);
        }

        [HttpGet("GetAuthorDto/{AuthorId}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorDto(int AuthorId)
        {
            var author = await _uow.BookRepo.GetAuthor(AuthorId);
            return Ok(author.ToAuthorDto());
        }

        /// <summary>
        /// This Function returns all Authors from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Index()
        {
            var Authors = await _uow.BookRepo.GetAllAuthor();
            return Ok(Authors.Select(s => s.ToAuthorDto()));
        }
    }
}
