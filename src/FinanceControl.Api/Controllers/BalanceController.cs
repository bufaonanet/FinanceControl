using FinanceControl.Api.Application.Balance;
using FinanceControl.Api.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BalanceController : ControllerBase
{
    private readonly FinanceControlDbContext _context;
    
    public BalanceController(FinanceControlDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    
    [HttpGet(Name = "GetBalance")]
    public async Task<IActionResult> GetBalanceAsync()
    {
        var expenses = await _context.Expenses.SumAsync(expense => expense.Value);
        var incomes = await _context.Incomes.SumAsync(income => income.Value);

        var response = new BalanceResponse
        {
            Balance = incomes - expenses
        };

        return Ok(response);
    }
}