using DZ150524.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = "Server = (localdb)\\MSSQLLocalDB;Database = carsdb;Trusted_Connection=true";
builder.Services.AddDbContext<CarContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();

