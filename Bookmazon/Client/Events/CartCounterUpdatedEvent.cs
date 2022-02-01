namespace Bookmazon.Client.Events
{
    public class CartCounterUpdatedEvent : Event
    {
        public CartCounterUpdatedEvent() : base("cartCounterUpdated")
        {
            eventOption = new EventOption { SendLastEvent = true };
        }

    }
}
