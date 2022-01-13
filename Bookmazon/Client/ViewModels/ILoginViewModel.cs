namespace Bookmazon.Client.ViewModels
{
    public interface ILoginViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Task LoginUser();
    }
}
