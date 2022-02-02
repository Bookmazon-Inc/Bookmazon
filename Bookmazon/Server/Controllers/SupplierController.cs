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
    public class SupplierController : ControllerBase
    {
        private IUnitOfWork _uow;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        /// <summary>
        /// get all suppliers 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Index()
        {

            var suppliers = await _uow.SupplierRepo.GetAllSuppliers();

            return Ok(suppliers.Select(s => s.ToSupplierDto()));
        }
        
        /// <summary>
        /// This Function removes a book from the database
        /// </summary>
        /// <param name="bookDto"></param>
        [HttpPost("RemoveBook")]
        public async void RemoveBook(BookDto bookDto)
        {
            Book b = await _uow.BookRepo.GetBook(bookDto.ISBN);
            _uow.BookRepo.DeleteBook(b);
            _uow.Commit();
        }
        
        /// <summary>
        /// Get one book by ISBN
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        [HttpGet("{ISBN}")]
        public async Task<ActionResult<BookDto>> GetByISBN(string ISBN)
        {
            var book = await _uow.BookRepo.GetBook(ISBN);

            if(book == null)
                return NotFound();


            return book.ToBookDto();
        }


        /// <summary>
        /// This function adds a new book to the database
        /// </summary>
        /// <param name="bookDto"></param>
        [HttpPost("AddBook")]
        public void AddBook(BookCreateDto bookDto)
        {
            Book b = new Book { 
                ISBN = bookDto.ISBN,
                Title = bookDto.Title,
                Description = bookDto.Description,
                PictureURL = bookDto.PictureURL,
                NetPriceSell = bookDto.NetPriceSell,
                PricePurchase = bookDto.PricePurchase,
                LanguageCode = bookDto.LanguageCode,
                GenreID = bookDto.GenreID,
                PublisherID = bookDto.PublisherID,
                VATID = bookDto.VATID
            };

            _uow.BookRepo.AddBook(b);
            // Connect Author and Book
            //foreach (int id in bookDto.AuthorIds)
            //{
            //    _uow.BookRepo.ConnectAuthorToBook(bookDto.ISBN, id);
            //}

            _uow.Commit();
        }
    }
}
