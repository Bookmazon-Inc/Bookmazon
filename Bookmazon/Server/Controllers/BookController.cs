using Bookmazon.Server.Filter;
using Bookmazon.Server.Interfaces;
using Bookmazon.Server.Repos;
using Bookmazon.Shared.Dtos.Book;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookmazon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// get all books - use the book filter to filter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Index()
        {
            var bookFilter = new BookFilter();

            bookFilter.FromQueryString(Request.QueryString.ToString());

            var books = await _unitOfWork.BookRepo.GetAllBooks(bookFilter);

            return Ok(books.Select(s => s.ToBookDto()));
        }

        /// <summary>
        /// Get one book by ISBN
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        [HttpGet("{ISBN}")]
        public async Task<ActionResult<BookDto>> GetByISBN(string ISBN)
        {
            var book = await _unitOfWork.BookRepo.GetBook(ISBN);

            if(book == null)
                return NotFound();


            return book.ToBookDto();
        }


    }
}
