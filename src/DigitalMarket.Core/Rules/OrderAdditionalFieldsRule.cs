using DigitalMarket.Core.Contracts;
using DigitalMarket.Data.Enums;

namespace DigitalMarket.Core.Rules;

// TODO: This rule could be divided by partner and rules could
// be sourced by a table via distributed cache.
// Also partners must be sourced by collection or table
public class OrderAdditionalFieldsRule : IBusinessRule
{
    private readonly CreateOrderRequest _createOrderRequest;
    

    public OrderAdditionalFieldsRule(
        CreateOrderRequest orderRequest)
    {
        _createOrderRequest = orderRequest;
    }

    public bool IsBroken() {
        switch (_createOrderRequest.Partner)
        {
            case nameof(Partner.PartnerA) when _createOrderRequest.AdditionalInfo == null || 
                                                string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.ContactFirstName) ||
                                                string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.ContactLastName) ||
                                                string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.ContactTitle) ||
                                                string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.ContactPhone) ||
                                                string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.ContactMobile) ||
                                                string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.ContactEmail):
            case nameof(Partner.PartnerC) when _createOrderRequest.AdditionalInfo == null || 
                                               string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.ExposureID) ||
                                               string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.UDAC) ||
                                               string.IsNullOrEmpty(_createOrderRequest.AdditionalInfo.RelatedOrder):
                return true;
            default:
                return false;
        }
    }

    public string Message => $"Invalid additional fields for {_createOrderRequest.Partner}";
}