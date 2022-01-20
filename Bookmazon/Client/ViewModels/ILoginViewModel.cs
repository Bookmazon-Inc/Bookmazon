using Bookmazon.Shared.Models.Authentication;

namespace Bookmazon.Client.ViewModels
{
    public interface ILoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Task LoginUser();
        public Task<AuthenticationResponse> AuthenticateJwt();
    }
}
