using Bookmazon.Shared.Filter;
using Microsoft.AspNetCore.Components;

namespace Bookmazon.Client.Services
{
    public class BookSearchService
    {

        public event EventHandler<string> OnSearchRequest;


        private NavigationManager _nav;

        public BookSearchService(NavigationManager nav)
        {
            _nav = nav;
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
                OnSearchRequest?.Invoke(this, searchString);
            } else
            {
                var filter = new LikeFilter
                {
                    PropertyName = "searchString",
                    Value = searchString
                };


                _nav.NavigateTo($"/books?{filter.ToQueryString()}");
            }
        }
    }
}
