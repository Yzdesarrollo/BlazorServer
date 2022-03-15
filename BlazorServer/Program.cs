using Blazored.LocalStorage;
using BlazorServer.Data;
using BlazorServer.Models;
using BlazorServer.Providers;
using BlazorServer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Connection String Database
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MiTiendaDbContext>(options =>
options.UseSqlServer(ConnectionString));

#region Servicios
builder.Services.AddScoped<RolesServices>();
builder.Services.AddScoped<UsuariosServices>();
builder.Services.AddScoped<CategoriaServices>();
builder.Services.AddScoped<ProductoServices>();
builder.Services.AddScoped<ClienteServices>();
builder.Services.AddScoped<FacturaServices>();
#endregion

#region Providers
builder.Services.AddScoped<AuthProvider>();
builder.Services.AddScoped<AuthenticationStateProvider,MiAuthenticationState>();
#endregion

builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
