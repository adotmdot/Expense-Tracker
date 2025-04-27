public class ExpenseService
{
    public List<Expense> Expenses { get; set; } = new List<Expense>();

    public void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
    }
}

public class Expense
{
    public string Title { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
