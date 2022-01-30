using Blazored.LocalStorage;
using Bookmazon.Client;
using Bookmazon.Client.ViewModels;
using Bookmazon.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



//
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
AddHttpClients(builder);

builder.Services.AddSingleton<BookSearchService>();
builder.Services.AddSingleton<CartService>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<CustomAuthHandler>();

builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();

static void AddHttpClients(WebAssemblyHostBuilder builder)
{
    builder.Services.AddHttpClient("StandardClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
    //.AddHttpMessageHandler<CustomAuthHandler>();
    builder.Services.AddHttpClient<IRegisterViewModel, RegisterViewModel>
        ("BookmazonRegisterClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
    builder.Services.AddHttpClient<ILoginViewModel, LoginViewModel>
        ("BookmazonLoginClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
}
