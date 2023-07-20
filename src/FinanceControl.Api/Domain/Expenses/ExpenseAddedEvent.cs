﻿namespace FinanceControl.Api.Domain.Expenses;

public class ExpenseAddedEvent
{
    public decimal Value { get; set; }

    public string EventName => nameof(ExpenseAddedEvent);
}