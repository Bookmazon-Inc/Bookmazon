using Blazored.LocalStorage;
using Bookmazon.Shared.Dtos.Book;
using Bookmazon.Shared.Dtos.Cart;

namespace Bookmazon.Client.Services
{
    public class CartService
    {
        public IList<CartItemDto> cartItems = new List<CartItemDto>();

        private ILocalStorageService _localStore;

        private const string STORE_KEY = "cartItems";

        public CartService(ILocalStorageService localStore)
        {
            _localStore = localStore;

            setAllCartItems();
        }


        public void AddToCart(BookDto bookDto, int amount)
        {
            var cartItem = new CartItemDto
            {
                Amount = amount,
                Description = bookDto.Description,
                ISBN = bookDto.ISBN,
                PictureURL = bookDto.PictureURL,
                Price = bookDto.Price,
                Title = bookDto.Title,
            };

            cartItems.Add(cartItem);

            _localStore.SetItemAsync(STORE_KEY, cartItem);
        }


        private async void setAllCartItems()
        {
            cartItems = await _localStore.GetItemAsync<IList<CartItemDto>>(STORE_KEY);
        }
    }
}
