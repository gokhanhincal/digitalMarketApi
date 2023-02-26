using DigitalMarket.Core.Contracts;
using DigitalMarket.Data.Enums;
using Microsoft.Extensions.Logging;

namespace DigitalMarket.Core.Rules;

// TODO: This rule could be divided by partner and rules could
// be sourced by a table via distributed cache.
// Also partners must be sourced by collection or table

public class OrderCreationRule : IBusinessRule
{
    private readonly CreateOrderRequest _createOrderRequest;
    private readonly ILogger<OrderCreationRule> _logger;

    public OrderCreationRule(
        CreateOrderRequest orderRequest)
    {
        _createOrderRequest = orderRequest;
    }

    public bool IsBroken() {
        switch (_createOrderRequest.Partner)
        {
            case nameof(Partner.PartnerA) when _createOrderRequest.LineItems.Count > 1 || 
                                               _createOrderRequest.LineItems.Any(x => x.ProductType == nameof(OrderedProductType.PaidSearch)):
            case nameof(Partner.PartnerD) when _createOrderRequest.LineItems.Count > 1 || 
                                               _createOrderRequest.LineItems.Any(x => x.ProductType == nameof(OrderedProductType.WebSite)):
                return true;
            default:
                return false;
        }
    }

    public string Message => $"Invalid order products for {_createOrderRequest.Partner}";
}