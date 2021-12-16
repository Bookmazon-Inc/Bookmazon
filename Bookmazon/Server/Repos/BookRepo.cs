using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces.Filter;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmazon.Server.Repos
{
    public class BookRepo : IBookRepo
    {
        public BookRepo(DBContext context)
        {
            _dbc = context;
        }
        
        // Privates 
        private DBContext _dbc;

        #region Book
        /// <summary>
        /// Returns a specific book
        /// </summary>
        /// <param name="ISBN">The Id of wanted book</param>
        /// <returns></returns>
        public async Task<Book?> GetBook(string ISBN)
        {
            return await _dbc.Books.FindAsync(ISBN);
        }
        /// <summary>
        /// Returns all books from DB. A optinal filter can be added to narrow down the search
        /// </summary>
        /// <param name="bookFilter">The optional filter</param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> GetAllBooks(IBookFilter? bookFilter)
        {
            var query = from b in _dbc.Books
                        select b;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Adds a Book to the database
        /// </summary>
        /// <param name="book">The book to add</param>
        public void AddBook(Book book)
        {
            _dbc.Books.Add(book);
        }
        /// <summary>
        /// Updates the values of a book
        /// </summary>
        /// <param name="book">THe book to update</param>
        public void UpdateBook(Book book) 
        { 
            _dbc.Books.Update(book);
        }
        /// <summary>
        /// Removes a book from the database
        /// </summary>
        /// <param name="book"></param>
        public void DeleteBook(Book book)
        {
            _dbc.Books.Remove(book);
        }
        #endregion

        #region VAT
        /// <summary>
        /// Returns a specific VAT (Umsatzsteuer)
        /// </summary>
        /// <param name="VATID">The Id of the VAT</param>
        /// <returns></returns>
        public async Task<VAT?> GetVAT(int VATID)
        {
            return await _dbc.VAT.FindAsync(VATID);
        }
        /// <summary>
        /// Returns all VATs (Umsatzsteuern) in the database
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<VAT>> GetAllVATs()
        {
            var query = from v in _dbc.VAT
                        select v;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Adds a VAT to the database
        /// </summary>
        /// <param name="vat"></param>
        public void AddVAT(VAT vat)
        {
            _dbc.VAT.Add(vat);
        }
        /// <summary>
        /// Updates the values of a vat
        /// </summary>
        /// <param name="vat"></param>
        public void UpdateVAT(VAT vat)
        {
            _dbc.VAT.Update(vat);
        }
        /// <summary>
        /// Removes a vat from the database
        /// </summary>
        /// <param name="VAT"></param>
        public void DeleteVAT(VAT VAT)
        {
            _dbc.VAT.Remove(VAT);
        }

        #endregion

        #region Language
        Task<Language?> GetLanguage(string languageCode);
        Task<IEnumerable<Language>> GetAllLanguages();
        void AddLanguage(Language language);
        void UpdateLanguage(Language language);
        void DeleteLanguage(Language language);
        #endregion

        #region Genre
        Task<Genre?> GetGenre(int genreId);
        Task<IEnumerable<Genre>> GetAllGenre();
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Genre genre);
        #endregion

        #region Author
        Task<Author?> GetAuthor(int authorId);
        Task<IEnumerable<Author>> GetAllAuthor();
        void AddAuthor(Author author);
        void ConnectAuthorToBook(string ISBN, int AuthorId);
        void RemoveAuthorFromBook(string ISBN, int AuthorId);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
        #endregion

        #region Publisher
        Task<Publisher?> GetPublisher(int publisherId);
        Task<IEnumerable<Publisher>> GetAllPublisher();
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
        #endregion
    }
}
