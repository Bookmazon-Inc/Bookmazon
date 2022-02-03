using Bookmazon.Server.Data;
using Bookmazon.Shared;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookmazon.Server.Controllers
{
    /// <summary>
    /// This Controller is used to seed the Database
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly DBContext _dbc;

        /// <summary>
        /// Constructor of class
        /// </summary>
        public SeedController(DBContext dbc)
        {
            _dbc = dbc;
        }

        /// <summary>
        /// This Method fills the database with data (duh)
        /// </summary>
        [HttpGet("SeedUP")]
        public void SeedUP()
        {
            #region Objects
            StorageLocation sloc1 = new StorageLocation { StorageLocationID = 1, LocationName = "Location 1" };
            StorageLocation sloc2 = new StorageLocation { StorageLocationID = 2, LocationName = "Location 2" };
            StorageLocation sloc3 = new StorageLocation { StorageLocationID = 3, LocationName = "Location 3" };

            CustomerOrderState costate1 = new CustomerOrderState { CustomerOrderStateId = 1, Title = "New" };
            CustomerOrderState costate2 = new CustomerOrderState { CustomerOrderStateId = 2, Title = "In packaging" };
            CustomerOrderState costate3 = new CustomerOrderState { CustomerOrderStateId = 3, Title = "Packaged" };
            CustomerOrderState costate4 = new CustomerOrderState { CustomerOrderStateId = 4, Title = "Sent" };
            CustomerOrderState costate5 = new CustomerOrderState { CustomerOrderStateId = 5, Title = "Arrived" };

            CustomerOrderPositionState cosstate1 = new CustomerOrderPositionState { CustomerOrderPositionStateId = 1, Title = "In Packaging" };
            CustomerOrderPositionState cosstate2 = new CustomerOrderPositionState { CustomerOrderPositionStateId = 2, Title = "Packaged" };

            SupplyOrderState sustate1 = new SupplyOrderState { SupplyOrderStateID = 1, Title = "Not yet released" };
            SupplyOrderState sustate2 = new SupplyOrderState { SupplyOrderStateID = 2, Title = "Ordered" };
            SupplyOrderState sustate3 = new SupplyOrderState { SupplyOrderStateID = 3, Title = "Arrived" };

            SupplyOrderPositionState supstate1 = new SupplyOrderPositionState { SupplyOrderPositionStateID = 1, Title = "Ordered" };
            SupplyOrderPositionState supstate2 = new SupplyOrderPositionState { SupplyOrderPositionStateID = 2, Title = "Arrived" };

            Language de = new Language { LanguageCode = "de", FullName = "Deutsch/German" };
            Language en = new Language { LanguageCode = "en", FullName = "English" };

            Publisher pub1 = new Publisher { PublisherId = 1, PublisherName = "Kazé Manga Deutschland" };
            Publisher pub2 = new Publisher { PublisherId = 2, PublisherName = "Panini S.p.A." };
            Publisher pub3 = new Publisher { PublisherId = 3, PublisherName = "Ullstein Verlag" };

            Roles role1 = new Roles { RoleID = 1, RoleName = "admin" };
            Roles role2 = new Roles { RoleID = 2, RoleName = "customer" };
            Roles role3 = new Roles { RoleID = 3, RoleName = "guest" };

            Genre gen1 = new Genre { GenreId = 1, Title = "Unknown" };
            Genre gen2 = new Genre { GenreId = 2, Title = "Thriller" };
            Genre gen3 = new Genre { GenreId = 3, Title = "Sachbuch" };
            Genre gen4 = new Genre { GenreId = 4, Title = "Humor" };
            Genre gen5 = new Genre { GenreId = 5, Title = "Manga" };

            VAT vat1 = new VAT { VATID = 1, VATPercentage = 10 };
            VAT vat2 = new VAT { VATID = 2, VATPercentage = 20 };

            Supplier sup1 = new Supplier { SupplierID = 1, Title = "AustrianBookSupplier GmbH", Land = "Austria", PostalCode = "6020", City = "Innsbruck", Street = "Boooksupplierstreet", HouseNumber = "1a", Email = "austrian@booksupplier.at"};
            Supplier sup2 = new Supplier { SupplierID = 2, Title = "Bookstore Yeldricius", Land = "Holy Empire Tyrol", PostalCode = "1", City = "Capital", Street = "Capitalcitystreet", HouseNumber = "0b", Email = "southtyroldidnothingwrong@yeldricius.com" };

            Author aut1 = new Author { AuthorId = 1, Firstname = "Marc-Uwe", Lastname = "Kling" };
            Author aut2 = new Author { AuthorId = 2, Firstname = "Paru", Lastname = "Itagaki" };

            Discount dis1 = new Discount { DiscountId = 1, DiscountName = "No Discount", Startdate = DateTime.Now, Enddate = DateTime.Now.AddYears(999) };
            Discount dis2 = new Discount { DiscountId = 2, DiscountName = "Default Sale", Startdate = DateTime.Now, Enddate = DateTime.Now.AddYears(99) };

            Book book1 = new Book
            {
                ISBN = "9783548372570",
                Title = "Die Känguru-Chroniken: Ansichten eines vorlauten Beuteltiers",
                Description = "'Ich bin ein Känguru - und Marc-Uwe ist mein Mitbewohner und Chronist. Nur manches, was er über mich erzählt, stimmt. Zum Beispiel, dass ich mal beim Vietcong war. Das Allermeiste jedoch ist übertrieben, verdreht oder gelogen! Aber ich darf nicht meckern. Wir gehen zusammen essen und ins Kino, und ich muss nix bezahlen.' Mal bissig, mal verschroben, dann wieder liebevoll ironisch wird der Alltag eines ungewöhnlichen Duos beleuchtet.",
                PictureURL = "https://assets.thalia.media/img/artikel/f2310c9f64498c54daea67690209c544c5bf496c-00-00.jpeg",
                NetPriceSell = 9.41m,
                PricePurchase = 2.99m,
                LanguageCode = de.LanguageCode,
                GenreID = gen4.GenreId,
                PublisherID = pub3.PublisherId,
                VATID = vat2.VATID
            };
            Book book2 = new Book
            {
                ISBN = "9782889512102",
                Title = "Beastars, Bd.1",
                Description = "Es ist ein brüchiger Frieden, der das Zusammenleben von Fleisch- und Pflanzenfressern ermöglicht, und besonders Grauwolf Legoshi spürt immer wieder, wie seine pflanzenfressenden Mitschüler ihm mit Angst begegnen. Dabei steckt hinter seinen scharfen Klauen und dem furchteinflößenden Aussehen ein sensibler Kerl. Als jedoch sein Alpaka-Freund Tem auf brutalste Art und Weise ermordet wird, drohen Misstrauen und Vorurteile in Hass umzuschlagen ...",
                PictureURL = "https://multimedia.knv.de/cover/78/52/28/7852285700001A.jpg",
                NetPriceSell = 6m,
                PricePurchase = 1.50m,
                LanguageCode = de.LanguageCode,
                GenreID = gen5.GenreId,
                PublisherID = pub1.PublisherId,
                VATID = vat2.VATID
            };

            SupplyOrder so1 = new SupplyOrder { SupplyOrderID = 1, SupplyOrderDate = new DateTime(2021, 11, 30), SupplierID = sup2.SupplierID, SupplyOrderStateID = 3 };
            SupplyOrder so2 = new SupplyOrder { SupplyOrderID = 2, SupplyOrderDate = new DateTime(2021, 11, 24), SupplierID = sup1.SupplierID, SupplyOrderStateID = 3 };

            SupplyOrderPosition sop1 = new SupplyOrderPosition { SupplyOrderID = 1, SupplyOrderPositionID = 1, Amount = 50, Price = book1.PricePurchase, Discount = 0, BookISBN = book1.ISBN, SupplyOrderPositionStateID = supstate2.SupplyOrderPositionStateID };
            SupplyOrderPosition sop2 = new SupplyOrderPosition { SupplyOrderID = 1, SupplyOrderPositionID = 2, Amount = 50, Price = book2.PricePurchase, Discount = 0, BookISBN = book2.ISBN, SupplyOrderPositionStateID = supstate2.SupplyOrderPositionStateID };
            SupplyOrderPosition sop3 = new SupplyOrderPosition { SupplyOrderID = 2, SupplyOrderPositionID = 1, Amount = 25, Price = book1.PricePurchase, Discount = 0, BookISBN = book1.ISBN, SupplyOrderPositionStateID = supstate2.SupplyOrderPositionStateID };

            Storage stor1 = new Storage { StorageLocationID = sloc1.StorageLocationID, ISBN = book1.ISBN, Amount = 50 };
            Storage stor2 = new Storage { StorageLocationID = sloc2.StorageLocationID, ISBN = book1.ISBN, Amount = 25 };
            Storage stor3 = new Storage { StorageLocationID = sloc3.StorageLocationID, ISBN = book2.ISBN, Amount = 50 };


            //password = TestAdminPassword
            User adminUser = new User { LastName = "TestAdminLastName",
                FirstName = "TestAdminFirstName",
                CompanyName = "TestAdminCompany",
                Email = "TestAdmin@email.com",
                Password = "mO7wFkhMrhKRcmUnVdO8n5Qvy8vthOqvUwj891opz2WqiU12Qzd6HjoO7YENaqg2TurCyJgGCxM=",
                Salt = "IoajMClJpbeZ0crKf0iVcJ1b2XfC0FtO",
                Roles = new List<Roles> { role1 } };
            //password = TestCustomerPassword
            User customerUser = new User { LastName = "TestCustomerLastName",
                FirstName = "TestCustomerFirstName",
                CompanyName = "TestCustomerCompany",
                Email = "TestCustomer@email.com",
                Password = "UG6Lav1nKevW41G0BjmXk0pJy7t3vlqA9c61erGPo8dhnEDCGRfw1aWChfpeg+VJdgvY0pzbxA8=",
                Salt = "uEN50wiLk1tn3ZEg73Jj5ex1SB75NWax",
                Roles = new List<Roles> { role2 } };

            #endregion


            using (var ts = _dbc.Database.BeginTransaction())
            {
                // This Wall of text sets Identity Insert of all tables that have an identity to true.
                // It Inserts the seed and sets Identity Insert back to off
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [str].[StorageLocation] ON");
                _dbc.StorageLocations.AddRange(sloc1, sloc2, sloc3);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [str].[StorageLocation] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[CustomerOrderState] ON");
                _dbc.CustomerOrderStates.AddRange(costate1, costate2, costate3, costate4, costate5);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[CustomerOrderState] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[CustomerOrderPositionState] ON");
                _dbc.CustomerOrderPositionStates.AddRange(cosstate1, cosstate2);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[CustomerOrderPositionState] OFF");


                _dbc.Languages.AddRange(de, en);
                _dbc.SaveChanges();


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Publisher] ON");
                _dbc.Publishers.AddRange(pub1, pub2, pub3);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Publisher] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [usr].[Roles] ON");
                _dbc.Roles.AddRange(role1, role2, role3);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [usr].[Roles] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Genre] ON");
                _dbc.Genres.AddRange(gen1, gen2, gen3, gen4, gen5);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Genre] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[VAT] ON");
                _dbc.VAT.AddRange(vat1, vat2);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[VAT] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Supplier] ON");
                _dbc.Suppliers.AddRange(sup1, sup2);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Supplier] OFF");



                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[SupplyOrderState] ON");
                _dbc.SupplyOrderStates.AddRange(sustate1, sustate2, sustate3);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[SupplyOrderState] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[SupplyOrderPositionState] ON");
                _dbc.SupplyOrderPositionStates.AddRange(supstate1, supstate2);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[SupplyOrderPositionState] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Author] ON");
                _dbc.Authors.AddRange(aut1, aut2);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Author] OFF");


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Discount] ON");
                _dbc.Discounts.AddRange(dis1, dis2);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [bok].[Discount] OFF");


                _dbc.Books.AddRange(book1, book2);
                _dbc.SaveChanges();


                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[SupplyOrder] ON");
                _dbc.SupplyOrders.AddRange(so1, so2);
                _dbc.SaveChanges();
                _dbc.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [ord].[SupplyOrder] OFF");


                _dbc.SupplyOrderPositions.AddRange(sop1, sop2, sop3);
                _dbc.Storages.AddRange(stor1, stor2, stor3);
                _dbc.SaveChanges();


                _dbc.Users.AddRange(adminUser, customerUser);
                _dbc.SaveChanges();


                ts.Commit();
            }
        }

        /// <summary>
        /// This function truncates the whole database
        /// </summary>
        [HttpGet("SeedDOWN")]
        public void SeedDOWN()
        {
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [str].[Storage]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [str].[StorageLocation]");

            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[AuthorBook]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[SupplyOrderPosition]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Book]");
            
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[BookDiscount]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[BookSupplier]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [usr].[RolesUser]");

            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Author]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Discount]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Genre]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Language]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Publisher]");

            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[SupplyOrderPosition]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[SupplyOrder]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[SupplyOrderPositionState]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[SupplyOrderState]");
            

            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[VAT]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Supplier]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [bok].[Book]");

            
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[CustomerOrderPosition]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[CustomerOrder]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[CustomerOrderPositionState]");
            _dbc.Database.ExecuteSqlRaw("DELETE FROM [ord].[CustomerOrderState]");

            _dbc.Database.ExecuteSqlRaw("DELETE FROM [usr].[Roles]");

            _dbc.Database.ExecuteSqlRaw("DELETE FROM [usr].[User]");

            _dbc.SaveChangesAsync();
        }

        /// <summary>
        /// This function combines the two previous seed functions. 
        /// It deletes ALL ENTRIES from the database and refilles them with the given seed
        /// </summary>
        [HttpGet("Reseed")]
        public void Reseed()
        {
            SeedDOWN();
            SeedUP();
        }
    }
}