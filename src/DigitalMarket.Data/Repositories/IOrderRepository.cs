using DigitalMarket.Data.Entities;

namespace DigitalMarket.Data.Repositories;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order item);
    Task<bool> CheckIfOrderExistsAsync(string Id);
}