using Bookmazon.Client.Events;
using Bookmazon.Shared.Dtos.Book;
using Bookmazon.Shared.Filter;
using Microsoft.AspNetCore.Components;

namespace Bookmazon.Client.Services
{
    public class BookSearchService
    {

        private NavigationManager _nav;
        private EventService _eventService;

        private SearchBookEvent SearchBookEvent = new SearchBookEvent(); 

        public BookSearchService(NavigationManager nav, EventService eventService)
        {
            _nav = nav;
            _eventService = eventService;
        }

        public void Search(string searchString)
        {
            if(String.IsNullOrEmpty(searchString))
            {
                _nav.NavigateTo("/");
                return;
            }


            if(_nav.Uri.Contains("/books"))
            {
                _eventService.SendEvent(SearchBookEvent, searchString);
            } else
            {
                var filter = new LikeFilter<BookDto>
                {
                    Name = "searchString",
                    Value = searchString
                };


                _nav.NavigateTo($"/books?{filter.ToQueryString()}");
            }
        }
    }
}
