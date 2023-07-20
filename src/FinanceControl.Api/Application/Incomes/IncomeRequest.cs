using FinanceControl.Api.Domain.Incomes;

namespace FinanceControl.Api.Application.Incomes;

public record IncomeRequest(
    decimal Value, 
    DateTime Date, 
    IncomeType Type, 
    bool Recurrent);