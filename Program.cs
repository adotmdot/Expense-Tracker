using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.API.Data;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// Add Razor Pages
builder.Services.AddRazorPages();

// ✅ Add a simple service to store expenses in memory
builder.Services.AddSingleton<ExpenseService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

=======
builder.Services.AddControllers();
AppContext.SetSwitch("Microsoft.EntityFrameworkCore.Issue9825", true);
builder.Services.AddDbContext<ExpenseContext>(options =>
    options.UseSqlite("Data Source=expenses.db"));

var app = builder.Build();
app.MapControllers();
>>>>>>> 93a8071b899bcfe8d3e06fb7f489eb0a915c51d2
app.Run();
