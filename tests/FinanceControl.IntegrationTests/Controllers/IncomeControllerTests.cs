using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using FinanceControl.Api.Application.Balance;
using FinanceControl.Api.Application.Expenses;
using FinanceControl.Api.Application.Incomes;
using FinanceControl.Api.Domain.Expenses;
using FinanceControl.Api.Domain.Incomes;
using FinanceControl.Api.Infra;

namespace FinanceControl.IntegrationTests.Controllers;

public class IncomeControllerTests : IClassFixture<FinanceControlApplicationFactory>
{
    private readonly FinanceControlApplicationFactory _webApplicationFactory;

    public IncomeControllerTests(FinanceControlApplicationFactory webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }


    [Fact]
    public async Task ShouldAddIncomeCorrectly()
    {
        var client = _webApplicationFactory.CreateClient();

        var request = new IncomeRequest(150, DateTime.UtcNow, IncomeType.Bonus, false);
        var body = JsonSerializer.Serialize(request);
        var stringContent = new StringContent(body, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("incomes", stringContent);
        var balanceResponse = await client.GetFromJsonAsync<BalanceResponse>("balance") ?? new BalanceResponse();

        var config = new ConsumerConfig
        {
            BootstrapServers = _webApplicationFactory.GetBootstrapAddress(),
            GroupId = "integrationTestsConsumer",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        
        var consumer = new ConsumerBuilder<Null, string>(config).Build();
        consumer.Subscribe(Consts.IncomesAddedTopicName);
        
        var kafkaMessage = consumer.Consume();
        var incomeAddedProducedEvent = JsonSerializer.Deserialize<IncomeAddedEvent>(kafkaMessage.Message.Value);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Equal(150, balanceResponse!.Balance);
        Assert.Equal(150, incomeAddedProducedEvent!.Value);
        Assert.Equal("IncomeAddedEvent", incomeAddedProducedEvent.EventName);

        //await _webApplicationFactory.ClearDatabaseAsync();
    }
    
    
}