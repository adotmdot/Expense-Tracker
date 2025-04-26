using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.API.Models;
using ExpenseTracker.API.Data;
using System.Collections.Generic;
using System.Linq;


namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseContext _context;
        public ExpensesController(ExpenseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses() =>
            _context.Expenses.ToList();

        [HttpPost]
        public ActionResult<Expense> PostExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null) return NotFound();
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return NoContent();
        }
    }
}