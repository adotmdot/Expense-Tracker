var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages
builder.Services.AddRazorPages();

// ✅ Register HttpClientFactory
builder.Services.AddHttpClient("ExpenseAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000"); // Or the actual API port
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages(); // Make sure this is here too!

app.Run();
