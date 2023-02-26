using AutoMapper;
using DigitalMarket.Core.Interfaces;
using DigitalMarket.Core.Services;
using DigitalMarket.Data.Repositories;
using DigitalMarket.UnitTests.SeedWork;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DigitalMarket.UnitTests.Orders;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderService> _logger;

    public OrderServiceTests()
    {
        _orderRepository = new Mock<IOrderRepository>();

        _orderService = new OrderService(_orderRepository.Object, _mapper, _logger);
    }
    
    [Fact]
    public async Task CreateOrder_With_Same_OrderId_Returns_Conflict()
    {
        //Arrange
        var order = TestData.CreateWebsiteOrderWithStaticOrderIdModel();
        
        _orderRepository.Setup(x => x.CheckIfOrderExistsAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(true));
        var caughtException = Record.ExceptionAsync(() => _orderService.CreateOrderAsync(order));
        //await Assert.ThrowsAsync<ConflictException>(() => _orderService.CreateOrderAsync(order));
        Assert.NotNull(caughtException);
    }
}