using Bookmazon.Shared.Models;
using Bookmazon.Shared.Models.Authentication;
using System.Net.Http.Json;

namespace Bookmazon.Client.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        public string UserName { get ; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private HttpClient _httpClient;

        public LoginViewModel()
        {
        }

        public LoginViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoginUser()
        {
            await _httpClient.PostAsJsonAsync<User>("user/loginuser", this);
        }

        public async Task<AuthenticationResponse> AuthenticateJwt()
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest();
            authenticationRequest.Email = this.Email;
            authenticationRequest.Password = this.Password;
            authenticationRequest.UserName = this.UserName;

            var httpMessageResponse = await _httpClient.PostAsJsonAsync<AuthenticationRequest>($"user/authenticatetoken", authenticationRequest);

            return await httpMessageResponse.Content.ReadFromJsonAsync<AuthenticationResponse>();
        }

        public static implicit operator LoginViewModel(User user)
        {
            return new LoginViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static implicit operator User(LoginViewModel loginViewModel)
        {
            return new User
            {
                UserName = loginViewModel.UserName,
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
        }
    }
}
