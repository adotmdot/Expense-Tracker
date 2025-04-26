using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
AppContext.SetSwitch("Microsoft.EntityFrameworkCore.Issue9825", true);
builder.Services.AddDbContext<ExpenseContext>(options =>
    options.UseSqlite("Data Source=expenses.db"));

var app = builder.Build();
app.MapControllers();
app.Run();
