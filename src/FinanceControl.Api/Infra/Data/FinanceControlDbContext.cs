using FinanceControl.Api.Domain.Expenses;
using FinanceControl.Api.Domain.Incomes;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Api.Infra.Data;

public class FinanceControlDbContext : DbContext
{
    public FinanceControlDbContext(DbContextOptions<FinanceControlDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Income> Incomes { get; set; }
}