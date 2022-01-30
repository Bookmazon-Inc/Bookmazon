using Bookmazon.Shared.Models;
using Bookmazon.Shared.Models.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace Bookmazon.Client.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
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
            await _httpClient.PostAsJsonAsync<User>("authorization/loginuser", this);
        }

        public async Task<AuthenticationResponse> AuthenticateJwt()
        {
            //creating authentication request
            AuthenticationRequest authenticationRequest = new AuthenticationRequest();
            authenticationRequest.Email = this.Email;
            authenticationRequest.Password = this.Password;

            //authenticating request
            var httpMessageResponse = await _httpClient.PostAsJsonAsync<AuthenticationRequest>($"authorization/authenticatetoken", authenticationRequest);

            //sending token to client
            return await httpMessageResponse.Content.ReadFromJsonAsync<AuthenticationResponse>();
        }

        public async Task<User> GetUserByJWTAsync(string token)
        {
            //preparing the http request
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "authorization/getuserbyjwt");
            requestMessage.Content = new StringContent(token);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            //making the http request
            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var returnedUser = await response.Content.ReadFromJsonAsync<User>();

            //returning the user if found
            if (returnedUser != null) return await Task.FromResult(returnedUser);
            else return null;
        }

        public static implicit operator LoginViewModel(User user)
        {
            return new LoginViewModel
            {
                Email = user.Email,
                Password = user.Password
            };
        }

        public static implicit operator User(LoginViewModel loginViewModel)
        {
            return new User
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
        }
    }
}
