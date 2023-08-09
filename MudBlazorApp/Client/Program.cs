using Application.Interfaces.Repositories;
using Infrastructure.ApiClient;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using MudBlazorApp.Client;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<AuditableContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefautlConnection")));
builder.Services.AddMudServices();
builder.Services.AddTransient<IUnitOfWork<int>, UnitOfWork<int>>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddSingleton<ApiClient>();
builder.Services.AddHttpClient();
/*builder.Services.AddScoped<IApiClient, ApiClient>(sp =>
{
    // Replace "your_base_url_here" with the actual base URL of your API.
    var baseUrl = "http://localhost:7234/api/CrystalReport";
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient();

    return new ApiClient(baseUrl, httpClient);
});*/

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
