using Bookmazon.Client.Events;
using System.ComponentModel;

namespace Bookmazon.Client.Services
{

    public class EventService
    {
        private Dictionary<string, Event> events { get; set; }
        
        
        public EventService()
        {
            events = new Dictionary<string, Event>();
        }


        public void AddEventHandler(Event eventToAdd, EventHandler<object> cb)
        {
            var Event = events.GetValueOrDefault(eventToAdd.Name);


            if(Event == null)
            {
                Event = eventToAdd;

                Event.AddHandler(cb);
                events.Add(eventToAdd.Name, Event);

                return;
            }

            Event.AddHandler(cb);
        }


        public void SendEvent(Event eventToSend, object args)
        {
            var Event = events.GetValueOrDefault(eventToSend.Name);

            if (Event != null)
            {
                Event.TriggerEvent(args);
            }
        }

        public void RemoveEventHandler(EventHandler<object> handler)
        {
            foreach (var Event in events.Values)
                Event.RemoveEventHandlder(handler);
        }



    }
}
