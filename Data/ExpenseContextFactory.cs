using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExpenseTracker.API.Data
{
    public class ExpenseContextFactory : IDesignTimeDbContextFactory<ExpenseContext>
    {
        public ExpenseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExpenseContext>();
            optionsBuilder.UseSqlite("Data Source=expenses.db");
            return new ExpenseContext(optionsBuilder.Options);
        }
    }
}