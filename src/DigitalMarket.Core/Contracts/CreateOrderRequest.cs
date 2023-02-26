using DigitalMarket.Core.Models;

namespace DigitalMarket.Core.Contracts;

public class CreateOrderRequest
{
    public string Partner { get; set; }
    public string OrderID { get; set; }
    public string TypeOfOrder { get; set; }
    public string SubmittedBy { get; set; }
    public string CompanyID { get; set; }
    public string CompanyName { get; set; }
    public IList<LineItemDto> LineItems { get; set; }
    public AdditionalInfoDto AdditionalInfo { get; set; }   
}