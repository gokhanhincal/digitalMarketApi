using DigitalMarket.Data.Entities;
using DigitalMarketing.Models;
using MongoDB.Driver;

namespace DigitalMarket.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _orders;

    public OrderRepository(IOrderDbSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
    }
    
    public async Task<Order> CreateOrderAsync(Order order)
    {
        try
        {
            await _orders.InsertOneAsync(order);
            return order;
        }
        catch (Exception ex)
        {
            throw new Exception("Error while writing to database", ex);
        }
    }

    public async Task<bool> CheckIfOrderExistsAsync(string Id)
    {
        try
        {
            return await _orders.Find(order => order.OrderID == Id).AnyAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error while getting order from database", ex);
        }
    }
}