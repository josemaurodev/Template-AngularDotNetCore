using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Template.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TemplateContext>();

var connectionString = builder.Configuration.GetConnectionString("TemplateDB");
builder.Services.AddDbContext<TemplateContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString)).EnableSensitiveDataLogging());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
