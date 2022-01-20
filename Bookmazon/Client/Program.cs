using Blazored.LocalStorage;
using Bookmazon.Client;
using Bookmazon.Client.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddTransient<CustomAuthHandler>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

AddHttpClients(builder);
//

await builder.Build().RunAsync();

static void AddHttpClients(WebAssemblyHostBuilder builder)
{
    builder.Services.AddHttpClient("StandardClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<CustomAuthHandler>();
    builder.Services.AddHttpClient<IRegisterViewModel, RegisterViewModel>
        ("BookmazonRegisterClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
    builder.Services.AddHttpClient<ILoginViewModel, LoginViewModel>
        ("BookmazonLoginClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
}
