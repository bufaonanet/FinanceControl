using FinanceControl.Api.Domain.Base;

namespace FinanceControl.Api.Domain.Incomes;

public class Income : Entity
{
    public decimal Value { get; set; }
    public IncomeType Type { get; set; }
    public DateTime Date { get; set; }
    public bool IsRecurrent { get; set; }
}