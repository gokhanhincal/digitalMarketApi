using System.Net;
using System.Text;
using DigitalMarket.IntegrationTests.SeedWork;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DigitalMarket.IntegrationTests;

public class OrdersControllerTests 
{
    private HttpClient _client;
    
    public OrdersControllerTests()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                });
            });
        _client = application.CreateClient();
    }

    [Fact]
    public async Task Create_order_post_return_created()
    {
        var request = new StringContent(TestData.CreateWebsiteOrderModel(), Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("api/v1/orders", request);
        
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
    
    [Fact]
    public async Task Create_order_post_with_same_orderId_returns_conflict()
    {
        var request1 = new StringContent(TestData.CreateWebsiteOrderWithStaticOrderIdModel(), Encoding.UTF8, "application/json");
        var request2 = new StringContent(TestData.CreateWebsiteOrderWithStaticOrderIdModel(), Encoding.UTF8, "application/json");
        
        var responseContent1 = await _client.PostAsync("api/v1/orders", request1);
        var responseContent2 = await _client.PostAsync("api/v1/orders", request2);
        
        Assert.Equal(HttpStatusCode.Conflict, responseContent2.StatusCode);
    }
    
    [Fact]
    public async Task Create_order_post_with_null_fields_returns_badRequest()
    {
        var request = new StringContent(TestData.CreateWebsiteOrderWithNullFieldsModel(), Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("api/v1/orders", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Create_order_post_with_invalid_product_returns_badRequest()
    {
        var request = new StringContent(TestData.CreateInvalidProductForPartner(), Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("api/v1/orders", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}



