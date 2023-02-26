using DigitalMarket.Core.Contracts;
using DigitalMarket.Core.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DigitalMarket.IntegrationTests.SeedWork;

public static class TestData
{
    public static string CreateWebsiteOrderModel()
    {
        var orderModel = new CreateOrderRequest()
        {
            Partner = "PartnerA",
            OrderID = Guid.NewGuid().ToString(),
            TypeOfOrder = "typeOfOrder",
            SubmittedBy = "submittedBy",
            CompanyID = "companyId",
            CompanyName = "companyName",
            AdditionalInfo = new AdditionalInfoDto
            {
                ContactEmail = "sdf@gmail.com",
                ContactMobile = "1232345",
                ContactPhone = "23455674",
                ContactTitle = "title",
                RelatedOrder = "relatedOrder",
                ContactFirstName = "firstName",
                ContactLastName = "lastName",
                ExposureID = "exposureId",
                UDAC = "udac"
            },
            LineItems = new List<LineItemDto>
            {
                new LineItemDto()
                {
                    ProductID = "1002",
                    ProductType = "Website",
                    Category = "Regular",
                    Notes = "Notes",
                    WebSiteDetails = new WebSiteDetailDto()
                    {
                        TemplateId =  "string",
                        WebsiteBusinessName = "string",
                        WebsiteAddressLine1 = "string",
                        WebsiteAddressLine2 = "string",
                        WebsiteCity = "string",
                        WebsiteState = "string",
                        WebsitePostCode = "string",
                        WebsitePhone = "string",
                        WebsiteEmail = "string",
                        WebsiteMobile = "string"
                    }
                }
            }
        };

        return JsonSerializer.Serialize(orderModel);
    }

    public static string CreateWebsiteOrderWithStaticOrderIdModel()
    {
        var orderModel = new CreateOrderRequest()
        {
            Partner = "PartnerA",
            OrderID = "orderId",
            TypeOfOrder = "typeOfOrder",
            SubmittedBy = "submittedBy",
            CompanyID = "companyId",
            CompanyName = "companyName",
            AdditionalInfo = new AdditionalInfoDto
            {
                ContactEmail = "sdf@gmail.com",
                ContactMobile = "1232345",
                ContactPhone = "23455674",
                ContactTitle = "title",
                RelatedOrder = "relatedOrder",
                ContactFirstName = "firstName",
                ContactLastName = "lastName",
                ExposureID = "exposureId",
                UDAC = "udac"
            },
            LineItems = new List<LineItemDto>
            {
                new LineItemDto()
                {
                    ProductID = "1002",
                    ProductType = "Website",
                    Category = "Regular",
                    Notes = "Notes",
                    WebSiteDetails = new WebSiteDetailDto()
                    {
                        TemplateId =  "string",
                        WebsiteBusinessName = "string",
                        WebsiteAddressLine1 = "string",
                        WebsiteAddressLine2 = "string",
                        WebsiteCity = "string",
                        WebsiteState = "string",
                        WebsitePostCode = "string",
                        WebsitePhone = "string",
                        WebsiteEmail = "string",
                        WebsiteMobile = "string"
                    }
                }
            }
        };

        return JsonSerializer.Serialize(orderModel);
    }
    
    public static string CreateWebsiteOrderWithNullFieldsModel()
    {
        var orderModel = new CreateOrderRequest()
        {
            Partner = "PartnerA",
            OrderID = Guid.NewGuid().ToString(),
            CompanyName = "companyName",
            AdditionalInfo = new AdditionalInfoDto
            {
                ContactEmail = "sdf@gmail.com",
                ContactMobile = "1232345",
                ContactPhone = "23455674",
                ContactTitle = "title",
                RelatedOrder = "relatedOrder",
                ContactFirstName = "firstName",
                ContactLastName = "lastName",
                ExposureID = "exposureId",
                UDAC = "udac"
            },
            LineItems = new List<LineItemDto>
            {
                new LineItemDto()
                {
                    ProductID = "1002",
                    ProductType = "Website",
                    Category = "Regular",
                    Notes = "Notes",
                    WebSiteDetails = new WebSiteDetailDto()
                    {
                        TemplateId =  "string",
                        WebsiteBusinessName = "string",
                        WebsiteAddressLine1 = "string",
                        WebsiteAddressLine2 = "string",
                        WebsiteCity = "string",
                        WebsiteState = "string",
                        WebsitePostCode = "string",
                        WebsitePhone = "string",
                        WebsiteEmail = "string",
                        WebsiteMobile = "string"
                    }
                }
            }
        };

        return JsonSerializer.Serialize(orderModel);
    }
    
    public static string CreateInvalidProductForPartner()
    {
        var orderModel = new CreateOrderRequest()
        {
            Partner = "PartnerA",
            OrderID = Guid.NewGuid().ToString(),
            TypeOfOrder = "typeOfOrder",
            SubmittedBy = "submittedBy",
            CompanyID = "companyId",
            CompanyName = "companyName",
            AdditionalInfo = new AdditionalInfoDto
            {
                ContactEmail = "sdf@gmail.com",
                ContactMobile = "1232345",
                ContactPhone = "23455674",
                ContactTitle = "title",
                RelatedOrder = "relatedOrder",
                ContactFirstName = "firstName",
                ContactLastName = "lastName",
                ExposureID = "exposureId",
                UDAC = "udac"
            },
            LineItems = new List<LineItemDto>
            {
                new LineItemDto()
                {
                    ProductID = "1002",
                    ProductType = "Website",
                    Category = "Regular",
                    Notes = "Notes",
                    AdWordCampaign = new PaidSearchDto()
                    {
                        Offer = "offer",
                        CampaignName = "CampName",
                        CampaignRadius = "CampaignRadius",
                        CampaignAddressLine1 = "CampaignAddressLine1",
                        CampaignPostCode = "CampaignPostCode",
                        LeadPhoneNumber = "LeadPhoneNumber",
                        UniqueSellingPoint1 = "UniqueSellingPoint1",
                        UniqueSellingPoint2 = "UniqueSellingPoint2",
                        UniqueSellingPoint3 = "UniqueSellingPoint3",
                        DestinationURL = "DestinationUrl",
                        SMSPhoneNumber = "SMSPhoneNumber"
                    }
                }
            }
        };

        return JsonSerializer.Serialize(orderModel);
    }
    
    public static string CreateOrderWithBothProducts()
    {
        var orderModel = new CreateOrderRequest()
        {
            Partner = "PartnerC",
            OrderID = Guid.NewGuid().ToString(),
            TypeOfOrder = "typeOfOrder",
            SubmittedBy = "submittedBy",
            CompanyID = "companyId",
            CompanyName = "companyName",
            AdditionalInfo = new AdditionalInfoDto
            {
                ContactEmail = "sdf@gmail.com",
                ContactMobile = "1232345",
                ContactPhone = "23455674",
                ContactTitle = "title",
                RelatedOrder = "relatedOrder",
                ContactFirstName = "firstName",
                ContactLastName = "lastName",
                ExposureID = "exposureId",
                UDAC = "udac"
            },
            LineItems = new List<LineItemDto>
            {
                new LineItemDto()
                {
                    ProductID = "1002",
                    ProductType = "Website",
                    Category = "Regular",
                    Notes = "Notes",
                    WebSiteDetails = new WebSiteDetailDto()
                    {
                        TemplateId =  "string",
                        WebsiteBusinessName = "string",
                        WebsiteAddressLine1 = "string",
                        WebsiteAddressLine2 = "string",
                        WebsiteCity = "string",
                        WebsiteState = "string",
                        WebsitePostCode = "string",
                        WebsitePhone = "string",
                        WebsiteEmail = "string",
                        WebsiteMobile = "string"
                    }
                },
                new LineItemDto()
                {
                    ProductID = "1002",
                    ProductType = "PaidSearch",
                    Category = "Regular",
                    Notes = "Notes",
                    AdWordCampaign = new PaidSearchDto()
                    {
                        Offer = "offer",
                        CampaignName = "CampName",
                        CampaignRadius = "CampaignRadius",
                        CampaignAddressLine1 = "CampaignAddressLine1",
                        CampaignPostCode = "CampaignPostCode",
                        LeadPhoneNumber = "LeadPhoneNumber",
                        UniqueSellingPoint1 = "UniqueSellingPoint1",
                        UniqueSellingPoint2 = "UniqueSellingPoint2",
                        UniqueSellingPoint3 = "UniqueSellingPoint3",
                        DestinationURL = "DestinationUrl",
                        SMSPhoneNumber = "SMSPhoneNumber"
                    }
                }
            }
        };

        return JsonSerializer.Serialize(orderModel);
    }
}