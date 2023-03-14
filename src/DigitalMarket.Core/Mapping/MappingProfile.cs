using AutoMapper;
using DigitalMarket.Core.Contracts;
using DigitalMarket.Core.Models;
using DigitalMarket.Data.Entities;

namespace DigitalMarket.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LineItemDto, LineItem>() 
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<AdditionalInfoDto, AdditionalInfo>();
        CreateMap<WebSiteDetailDto, WebSiteDetail>();
        CreateMap<PaidSearchDto, AdWordCampaign>();
        CreateMap<CreateOrderRequest, Order>()
            .ForMember(c => c.Id, option => option.Ignore())
            //.ForMember(c => c.AdditionalInfo, option => option.Ignore())
            .ForMember(c => c.LineItems, opt => opt.MapFrom(src => src.LineItems));
        
        CreateMap<Order, CreateOrderDto>();
        CreateMap<LineItem, LineItemDto>() 
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}