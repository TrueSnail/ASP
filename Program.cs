using E_Book_Store.Data;
using E_Book_Store.Models;
using E_Book_Store.Services;
using E_Book_Store.Validation;
using FluentValidation;
using FormHelper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("secrets.json");
builder.Services.AddControllersWithViews().AddFormHelper();
builder.Services.AddValidatorsFromAssemblyContaining<EBookValidator>();
builder.Services.AddDbContext<EBookDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IRepository<EBook>, EntityFrameworkRepository<EBook>>();
builder.Services.AddTransient<IEBooksService, EBooksService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
