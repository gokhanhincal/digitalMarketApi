namespace DigitalMarketing.Models;

public class OrderDbSettings : IOrderDbSettings
{
    public string OrdersCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}

public interface IOrderDbSettings
{
    string OrdersCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}