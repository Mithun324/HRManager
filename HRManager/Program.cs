using HRManager.Data;
using Microsoft.EntityFrameworkCore; // <-- This is all you need now!

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllersWithViews();

// 2. Configure Entity Framework Core with SQL Server
var connectionString = builder.Configuration.GetConnectionString("HRManagerConnection")
    ?? throw new InvalidOperationException("Connection string 'HRManagerConnection' not found.");

// UseSqlServer handles everything natively
builder.Services.AddDbContext<HRManagerDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
