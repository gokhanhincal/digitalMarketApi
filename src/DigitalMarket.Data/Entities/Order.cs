using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DigitalMarket.Data.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public string OrderID { get; set; }
    
    public string Partner { get; set; }

    public string TypeOfOrder { get; set; }

    public string SubmittedBy { get; set; }

    public string CompanyID { get; set; }
    
    public string CompanyName { get; set; }
    public IList<LineItem> LineItems { get; set; }
    public AdditionalInfo AdditionalInfo { get; set; }
}