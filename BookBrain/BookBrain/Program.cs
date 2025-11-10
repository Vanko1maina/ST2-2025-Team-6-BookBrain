using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookBrain.Data;
using Microsoft.EntityFrameworkCore;
using BookBrain.Services.Repositories;
using BookBrain.Data.Repositories;
using BookBrain.Models;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BookBrainDB"));

//  Регистрация на Repository за всички типове (Book, User, Loan)
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRepository<Loan>, LoanRepository>();
builder.Services.AddScoped<BookBrain.Services.Adapters.IAIAdapter, BookBrain.Services.Adapters.GPT4AllAdapter>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
