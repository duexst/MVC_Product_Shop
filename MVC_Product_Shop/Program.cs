using Microsoft.EntityFrameworkCore;
using MVC_Product_Shop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProduktShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:MVCProductShopDbContextConnection"]);
});


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

app.MapDefaultControllerRoute();

DbInitializer.Seed(app);

app.Run();
