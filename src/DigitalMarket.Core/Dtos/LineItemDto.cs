namespace DigitalMarket.Core.Models;

public class LineItemDto
{
    public string ProductID { get; set; }
    public string ProductType { get; set; } //TODO 
    public string Notes { get; set; }
    public string Category { get; set; }

    public WebSiteDetailDto? WebSiteDetails { get; set; }

    public PaidSearchDto? AdWordCampaign { get; set; }
}