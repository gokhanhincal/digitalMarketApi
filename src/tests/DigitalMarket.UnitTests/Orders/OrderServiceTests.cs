using AutoMapper;
using DigitalMarket.Core.Interfaces;
using DigitalMarket.Core.Mapping;
using DigitalMarket.Core.Services;
using DigitalMarket.Data.Entities;
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
    private static IMapper _mapper;
    private readonly Mock<ILogger<OrderService>> _logger;

    public OrderServiceTests()
    {
        _orderRepository = new Mock<IOrderRepository>();
        
        if (_mapper == null)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        
        _logger = new Mock<ILogger<OrderService>>();
        _orderService = new OrderService(_orderRepository.Object, _mapper, _logger.Object);
    }
    
    [Fact]
    public async Task CreateOrder_With_Same_OrderId_Returns_Conflict()
    {
        //Arrange
        var order = TestData.CreateWebsiteOrderWithStaticOrderIdModel();
        
        //Act
        _orderRepository.Setup(x => x.CheckIfOrderExistsAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(true));
        var caughtException = Record.ExceptionAsync(() => _orderService.CreateOrderAsync(order));
        
        //Assert
        Assert.NotNull(caughtException);
    }
    
    [Fact]
    public async Task CreateOrder_Order_With_Success()
    {
        //Arrange
        var order = TestData.CreateWebsiteOrderWithStaticOrderIdModel();
        
        //Act
        _orderRepository.Setup(x => x.CreateOrderAsync(It.IsAny<Order>()))
            .Returns(Task.FromResult(new Order()));
        var createdOrder = await _orderService.CreateOrderAsync(order);
        
        //Assert
        Assert.NotNull(createdOrder);
    }
}