using Microsoft.Extensions.Options;

namespace Bookmazon.Client.Events
{
    public abstract class Event
    {
        public string Name { get; private set; }

        protected EventOption eventOption;
        protected IList<EventHandler<object>> EventHandlers { get; set; } = new List<EventHandler<object>>();

        protected object _lastValue;


        public Event(string name)
        {
            Name = name;
            eventOption ??= new EventOption();
        }



        public void TriggerEvent(object args)
        {
            _lastValue = args;

            foreach (var handler in EventHandlers)
                handler.Invoke(this, args);
        }

        public void AddHandler(EventHandler<object> handler)
        {
            EventHandlers.Add(handler);

            if(eventOption.SendLastEvent && _lastValue != null)
            {
                handler.Invoke(this, _lastValue);
            }
        }


        public void RemoveEventHandlder(EventHandler<object> handlerToRemove)
        {
            foreach(var handler in EventHandlers)
            {
                if(handler == handlerToRemove)
                {
                    EventHandlers.Remove(handlerToRemove);
                }
            }
        }
    }
}
