using Bookmazon.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Net.Http;

namespace Bookmazon.Client.ViewModels
{
    public class RegisterViewModel : IRegisterViewModel
    {
        public string UserName { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        private HttpClient _httpClient;
        public RegisterViewModel()
        {

        }
        public RegisterViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task RegisterUser()
        {
            await _httpClient.PostAsJsonAsync<User>("/user/registeruser", this);
        }

        public static implicit operator RegisterViewModel(User user)
        {
            return new RegisterViewModel
            {
                UserName = user.UserName,
                LastName = user.LastName,
                FirstName = user.FirstName,
                CompanyName = user.CompanyName,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static implicit operator User(RegisterViewModel registerViewModel)
        {
            return new User
            {
                UserName = registerViewModel.UserName,
                LastName = registerViewModel.LastName,
                FirstName = registerViewModel.FirstName,
                CompanyName = registerViewModel.CompanyName,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password
            };
        }
    }
}
