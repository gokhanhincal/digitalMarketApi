using AutoMapper;
using DigitalMarket.Core.Contracts;
using DigitalMarket.Core.Exceptions;
using DigitalMarket.Core.Interfaces;
using DigitalMarket.Core.Models;
using DigitalMarket.Core.Rules;
using DigitalMarket.Data.Entities;
using DigitalMarket.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace DigitalMarket.Core.Services;

//TODO: Rules could be added to middleware
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderService> _logger;
    
    public OrderService(IOrderRepository orderRepository, IMapper mapper, ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<CreateOrderDto> CreateOrderAsync(CreateOrderRequest orderRequest)
    {
        CheckRules.Apply(new OrderCreationRule(orderRequest));
        CheckRules.Apply(new OrderAdditionalFieldsRule(orderRequest));
        
        var order = _mapper.Map<Order>(orderRequest);

        var orderExists = await _orderRepository.CheckIfOrderExistsAsync(orderRequest.OrderID);

        if (orderExists)
            throw new ConflictException($"Order already requested with ID => {orderRequest.OrderID}");
        
        await _orderRepository.CreateOrderAsync(order);
        _logger.LogInformation($"Order creation completed with Id {orderRequest.OrderID}");
        
        return _mapper.Map<CreateOrderDto>(order);
    }
}