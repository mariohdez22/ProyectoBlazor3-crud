using BlazorCrud.Client;
using BlazorCrud.Client.Services.Interfaces;
using BlazorCrud.Client.Services.Servicios;
using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7214") });

builder.Services.AddScoped<IPersonalService, PersonalService>();
builder.Services.AddScoped<IRangoPersonalService, RangoPersonalService>();

builder.Services.AddSweetAlert2();

builder.Services.AddBlazoredModal();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

await builder.Build().RunAsync();
