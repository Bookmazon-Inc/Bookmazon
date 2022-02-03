using Bookmazon.Server.Filter;
using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface IBookRepo
    {
        #region Book
        Task<Book?> GetBook(string ISBN);
        Task<IEnumerable<Book>> GetAllBooks(BookFilter? bookFilter);
        Task<IEnumerable<Book>> GetAllBooks(int supplierID);

        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);

        #endregion

        #region VAT
        Task<VAT?> GetVAT(int VATID);
        Task<ICollection<VAT>> GetAllVATs();
        void AddVAT(VAT vat);
        void UpdateVAT(VAT vat);
        void DeleteVAT(VAT VAT);

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
