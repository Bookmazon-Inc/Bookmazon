using Bookmazon.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Net.Http;

namespace Bookmazon.Client.ViewModels
{
    public class RegisterViewModel : IRegisterViewModel
    {
        [Required]
        [MinLength(4),MaxLength(12)]
        public string UserName { get; set; }


        public string? LastName { get; set; }


        public string? FirstName { get; set; }


        public string? CompanyName { get; set; }


        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [MinLength(8),MaxLength(64)]
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
            Console.WriteLine(this.UserName);
            Console.WriteLine(this.LastName);
            Console.WriteLine(this.FirstName);
            Console.WriteLine(this.CompanyName);
            Console.WriteLine(this.Email);
            Console.WriteLine(this.Password);
            await _httpClient.PostAsJsonAsync<User>("api/user/registeruser", this);
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
