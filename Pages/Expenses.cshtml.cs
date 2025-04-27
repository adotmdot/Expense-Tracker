using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ExpensesModel : PageModel
{
    private readonly ExpenseService _expenseService;

    public ExpensesModel(ExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [BindProperty]
    public Expense NewExpense { get; set; }

    public List<Expense> Expenses => _expenseService.Expenses;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            _expenseService.AddExpense(NewExpense);
            return RedirectToPage();
        }

        return Page();
    }
}
