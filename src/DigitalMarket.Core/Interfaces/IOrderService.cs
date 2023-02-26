using DigitalMarket.Core.Contracts;
using DigitalMarket.Core.Models;

namespace DigitalMarket.Core.Interfaces;

public interface IOrderService
{
    Task<CreateOrderDto> CreateOrderAsync(CreateOrderRequest order);
}