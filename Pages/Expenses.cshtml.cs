using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

public class ExpensesModel : PageModel
{
    private readonly IHttpClientFactory _clientFactory;
    public List<Expense> Expenses { get; set; } = new();

    [BindProperty]
    public Expense NewExpense { get; set; } = new();

    public ExpensesModel(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task OnGetAsync()
    {
        var client = _clientFactory.CreateClient("ExpenseAPI");
        Expenses = await client.GetFromJsonAsync<List<Expense>>("api/expenses") ?? new();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _clientFactory.CreateClient("ExpenseAPI");
        await client.PostAsJsonAsync("api/expenses", NewExpense);
        return RedirectToPage();
    }

    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
