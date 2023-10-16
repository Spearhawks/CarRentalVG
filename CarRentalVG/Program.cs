using CarRentalVG;
using CarRentalVG.Business.Classes;
using CarRentalVG.Data.Classes;
using CarRentalVG.Data.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<BookingManager>();
builder.Services.AddScoped<IData, Data>();

await builder.Build().RunAsync();
