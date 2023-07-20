using FinanceControl.Api.Domain.Expenses;

namespace FinanceControl.Api.Application.Expenses;

public record ExpenseRequest(
    decimal Value,
    DateTime Date,
    ExpenseType Type,
    bool Recurrent);