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



            Book book1 = new Book
            {
                ISBN = "9783548372570",
                Title = "Die Känguru-Chroniken: Ansichten eines vorlauten Beuteltiers",
                Description = "'Ich bin ein Känguru - und Marc-Uwe ist mein Mitbewohner und Chronist. Nur manches, was er über mich erzählt, stimmt. Zum Beispiel, dass ich mal beim Vietcong war. Das Allermeiste jedoch ist übertrieben, verdreht oder gelogen! Aber ich darf nicht meckern. Wir gehen zusammen essen und ins Kino, und ich muss nix bezahlen.' Mal bissig, mal verschroben, dann wieder liebevoll ironisch wird der Alltag eines ungewöhnlichen Duos beleuchtet.",
                PictureURL = "https://assets.thalia.media/img/artikel/154079d4058177b17311d9e33fb92f820a24c67e-00-00.jpeg",
                NetPriceSell = 9.41m,
                PricePurchase = 2.99m,
                LanguageCode = "",
                GenreID = 1,
                PublisherID = 1,
                VATID = 1
            };
            Book book2 = new Book
            {
                ISBN = "978-2-88951-210-2",
                Title = "Beastars, Bd.1",
                Description = "Es ist ein brüchiger Frieden, der das Zusammenleben von Fleisch- und Pflanzenfressern ermöglicht, und besonders Grauwolf Legoshi spürt immer wieder, wie seine pflanzenfressenden Mitschüler ihm mit Angst begegnen. Dabei steckt hinter seinen scharfen Klauen und dem furchteinflößenden Aussehen ein sensibler Kerl. Als jedoch sein Alpaka-Freund Tem auf brutalste Art und Weise ermordet wird, drohen Misstrauen und Vorurteile in Hass umzuschlagen ...",
                PictureURL = "https://multimedia.knv.de/cover/78/52/28/7852285700001A.jpg",
                NetPriceSell = 6m,
                PricePurchase = 1.50m,
                LanguageCode = "",
                GenreID = 1,
                PublisherID = 1,
                VATID = 1
            };


            var books = (new List<Book>() { book1, book2 }).AsQueryable();


            bookFilter.FromQueryString(Request.QueryString.ToString());

            bookFilter.ApplyFilter(books);
            

            //var books = await _unitOfWork.BookRepo.GetAllBooks(bookFilter);

            return Ok(books.Select(s => s.ToBookDto()));
        }


    }
}
