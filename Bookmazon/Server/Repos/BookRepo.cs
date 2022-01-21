using Bookmazon.Server.Data;
using Bookmazon.Server.Exceptions;
using Bookmazon.Server.Filter;
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
        public async Task<IEnumerable<Book>> GetAllBooks(BookFilter? bookFilter)
        {
            var query = from b in _dbc.Books
                        select b;

            if(bookFilter != null)
            {
                bookFilter.ApplyFilter(query);
            }

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
        /// <summary>
        /// Returns a specific Langage based on the languagecode
        /// </summary>
        /// <param name="languageCode">The 2 character long langagecode (Example: DE => german, EN => english)</param>
        /// <returns>Task of a language (async)</returns>
        public async Task<Language?> GetLanguage(string languageCode)
        {
            return await _dbc.Languages.FindAsync(languageCode);
        }
        /// <summary>
        /// Returns all langages in th database
        /// </summary>
        /// <returns>Task of IEnum of Languages (async)</returns>
        public async Task<IEnumerable<Language>> GetAllLanguages()
        {
            var query = from l in _dbc.Languages
                        select l;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Adds a new language to the database
        /// </summary>
        /// <param name="language">The language to add</param>
        public void AddLanguage(Language language)
        {
            _dbc.Languages.Add(language);
        }
        /// <summary>
        /// Updates the values of a language
        /// </summary>
        /// <param name="language">The language to update</param>
        public void UpdateLanguage(Language language)
        {
            _dbc.Languages.Update(language);
        }
        /// <summary>
        /// Removes a language from the database
        /// </summary>
        /// <param name="language">The language to remove</param>
        public void DeleteLanguage(Language language)
        {
            _dbc.Languages.Remove(language);
        }
        #endregion

        #region Genre
        /// <summary>
        /// Gets a specific genre from the database
        /// </summary>
        /// <param name="genreId">The id to look for</param>
        /// <returns></returns>
        public async Task<Genre?> GetGenre(int genreId)
        {
            return await _dbc.Genres.FindAsync(genreId);
        }
        /// <summary>
        /// Returns all Genres from the database 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Genre>> GetAllGenre()
        {
            var query = from g in _dbc.Genres
                        select g;

            return await query.ToArrayAsync();
        }
        
        /// <summary>
        /// Adds a new Genre to the database
        /// </summary>
        /// <param name="genre">The genre to add</param>
        public void AddGenre(Genre genre) 
        { 
            _dbc.Genres.Add(genre); 
        }
        /// <summary>
        /// Updates the values of a genre
        /// </summary>
        /// <param name="genre">The genre to update</param>
        public void UpdateGenre(Genre genre) 
        { 
            _dbc.Genres.Update(genre); 
        }
        /// <summary>
        /// Removes a genre from the database
        /// </summary>
        /// <param name="genre">The genre to remove</param>
        public void DeleteGenre(Genre genre)
        {
            _dbc.Genres.Remove(genre);
        }
        #endregion

        #region Author
        /// <summary>
        /// Returns a specific author from the database
        /// </summary>
        /// <param name="authorId">The Id of the Author</param>
        /// <returns></returns>
        public async Task<Author?> GetAuthor(int authorId)
        {
            return await _dbc.Authors.FindAsync(authorId); 
        }
        /// <summary>
        /// Returns all Authors that are in the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            var query = from a in _dbc.Authors
                        select a;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Adds an author to the database
        /// </summary>
        /// <param name="author"></param>
        public void AddAuthor(Author author)
        {
            _dbc.Authors.Add(author);
        }
        /// <summary>
        /// Connects a Author with a book via an intermediate table 
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="AuthorId"></param>
        /// <exception cref="EntityNotFoundException">This exception will be throw if no book or Author has been found</exception>
        public void ConnectAuthorToBook(string ISBN, int AuthorId)
        {
            Book book = _dbc.Books.Find(ISBN);
            Author author = _dbc.Authors.Find(AuthorId);

            // Check if Role and User exist
            if (book == null) throw new EntityNotFoundException(nameof(book));
            if (author == null) throw new EntityNotFoundException(nameof(author));

            author.Books.Add(book);
        }
        /// <summary>
        /// Removes the connection between an author and an book
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="AuthorId"></param>
        /// <exception cref="EntityNotFoundException">This exception will be throw if no book or Author has been found</exception>
        public void RemoveAuthorFromBook(string ISBN, int AuthorId)
        {
            Book book = _dbc.Books.Find(ISBN);
            Author author = _dbc.Authors.Find(AuthorId);

            // Check if Role and User exist
            if (book == null) throw new EntityNotFoundException(nameof(book));
            if (author == null) throw new EntityNotFoundException(nameof(author));

        }
        /// <summary>
        /// Updates the values of an author
        /// </summary>
        /// <param name="author">The author to update</param>
        public void UpdateAuthor(Author author) 
        { 
            _dbc.Authors.Update(author);
        }
        /// <summary>
        /// Removes an Author from the database
        /// </summary>
        /// <param name="author">The author to remove</param>
        public void DeleteAuthor(Author author)
        {
            _dbc.Authors.Remove(author);
        }
        #endregion

        #region Publisher
        /// <summary>
        /// Gets a specific publisher from the databse
        /// </summary>
        /// <param name="publisherId">the id of the publisher</param>
        /// <returns></returns>
        public async Task<Publisher?> GetPublisher(int publisherId)
        {
            return await _dbc.Publishers.FindAsync(publisherId);
        }
        /// <summary>
        /// Returns all publishers from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Publisher>> GetAllPublisher()
        {
            var query = from p in _dbc.Publishers
                        select p;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Adds a new publisher to the database
        /// </summary>
        /// <param name="publisher">The publisher to add</param>
        public void AddPublisher(Publisher publisher)
        {
            _dbc.Publishers.Add(publisher);
        }
        /// <summary>
        /// Updates the values of a publisher
        /// </summary>
        /// <param name="publisher">The publisher to update</param>
        public void UpdatePublisher(Publisher publisher)
        {
            _dbc.Publishers.Update(publisher);
        }
        /// <summary>
        /// Removes a Publisher from the database
        /// </summary>
        /// <param name="publisher">The publisher to remove</param>
        public void DeletePublisher(Publisher publisher)
        {
            _dbc.Publishers.Remove(publisher);
        }
        #endregion
    }
}
