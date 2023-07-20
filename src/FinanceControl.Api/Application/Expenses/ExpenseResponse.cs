using FinanceControl.Api.Domain.Expenses;

namespace FinanceControl.Api.Application.Expenses;

public class ExpenseResponse
{
    public Guid Id { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }

    public static implicit operator ExpenseResponse(Expense expense) => new ExpenseResponse
    {
        Id = expense.Id,
        Value = expense.Value,
        Date = expense.Date,
    };
}