using CarRentalVG;
using CarRentalVG.Business;
using CarRentalVG.Data.Classes;
using CarRentalVG.Data.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<BookingManager>();
builder.Services.AddSingleton<IData, Data>();

await builder.Build().RunAsync();
