using Blazored.LocalStorage;
using Bookmazon.Client.Events;
using Bookmazon.Shared.Dtos.Book;
using Bookmazon.Shared.Dtos.Cart;

namespace Bookmazon.Client.Services
{
    public class CartService
    {
        public IList<CartItemDto> cartItems = new List<CartItemDto>();

        private ILocalStorageService _localStore;
        private EventService _eventService;

        private const string STORE_KEY = "cartItems";
        private CartItemAddedEvent cartItemAddedEvent = new CartItemAddedEvent();
        private CartCounterUpdatedEvent cartCounterUpdatedEvent = new CartCounterUpdatedEvent();

        public CartService(ILocalStorageService localStore, EventService eventService)
        {
            _localStore = localStore;
            _eventService = eventService;

            setAllCartItems();
        }


        public void AddToCart(BookDto bookDto, int amount)
        {

            var cartItem = cartItems.FirstOrDefault(c => c.ISBN == bookDto.ISBN);


            if(cartItem == null)
            {
                cartItem = new CartItemDto
                {
                    Amount = amount,
                    Description = bookDto.Description,
                    ISBN = bookDto.ISBN,
                    PictureURL = bookDto.PictureURL,
                    Price = bookDto.Price,
                    Title = bookDto.Title,
                };

                cartItems.Add(cartItem);

                _localStore.SetItemAsync(STORE_KEY, cartItems);
                _eventService.SendEvent(cartItemAddedEvent, cartItem);
                _eventService.SendEvent(cartCounterUpdatedEvent, cartItems.Count());
                return;
            }

            cartItem.Amount += amount;


            _localStore.SetItemAsync(STORE_KEY, cartItems);
            _eventService.SendEvent(cartItemAddedEvent, cartItem);
        }

        public void UpdateAmount(string ISBN, int newAmount)
        {
            var cartItem = cartItems.FirstOrDefault(x => x.ISBN == ISBN);

            if (cartItem == null)
                return;

            if (newAmount <= 0) 
            {
                RemoveFromCart(ISBN);
                return;
            }

            cartItem.Amount = newAmount;
            _localStore.SetItemAsync(STORE_KEY, cartItems);
        }

        public void RemoveFromCart(string ISBN)
        {
            var cartItem = cartItems.FirstOrDefault(x => x.ISBN == ISBN);

            if (cartItem == null)
                return;

            cartItems.Remove(cartItem);
            _localStore.SetItemAsync(STORE_KEY, cartItems);
            _eventService.SendEvent(cartCounterUpdatedEvent, cartItems.Count());
        }

        private async void setAllCartItems()

        {
            cartItems = await _localStore.GetItemAsync<IList<CartItemDto>>(STORE_KEY);

            if(cartItems == null)
            {
                cartItems = new List<CartItemDto>();
            }

            _eventService.SendEvent(cartCounterUpdatedEvent, cartItems.Count());
        }

    }
}
