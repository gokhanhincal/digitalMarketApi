using MongoDB.Bson.Serialization.Attributes;

namespace DigitalMarket.Data.Entities;

public class LineItem
{
    public string ProductID { get; set; }
    public string ProductType { get; set; }
    public string Notes { get; set; }
    public string Category { get; set; }
    
    [BsonIgnoreIfNull]
    public WebSiteDetail WebSiteDetails { get; set; }
    
    [BsonIgnoreIfNull]
    public AdWordCampaign AdWordCampaign { get; set; }
}