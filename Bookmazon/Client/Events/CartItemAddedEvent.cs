namespace Bookmazon.Client.Events
{
    public class CartItemAddedEvent : Event
    {
        public CartItemAddedEvent() : base("cartItemAdded")
        {

        }
    }
}
