using FinanceControl.Api.Application.Incomes;
using FinanceControl.Api.Domain.Incomes;
using FinanceControl.Api.Infra;
using FinanceControl.Api.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomesController : ControllerBase
{
    [HttpPost(Name = "CreateIncome")]
    public async Task<IActionResult> CreateIncomeAsync(
        [FromBody] IncomeRequest request,
        [FromServices] FinanceControlDbContext context,
        [FromServices] BrokerService brokerService)
    {
        var income = new Income
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Date = request.Date,
            IsRecurrent = request.Recurrent,
            Type = request.Type,
            Value = request.Value
        };

        context.Add(income);

        await context.SaveChangesAsync();
        await brokerService.SendMessageAsync(
            new IncomeAddedEvent
            {
                Value = income.Value
            }, Consts.IncomesAddedTopicName);

        return Created("incomes", income);
    }  
}