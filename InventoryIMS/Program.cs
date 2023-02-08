using InventoryIMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("constr");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(Options=>
{
    Options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddDbContext<dbSampleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProductCon}/{action=Product}/{id?}");

app.Run();
