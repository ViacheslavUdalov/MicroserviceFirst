using AutoMapper;
using MicroserviceFirst.DTOs;
using MicroserviceFirst.Entities;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace MicroserviceFirst.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDTo>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDTo>();
        CreateMap<CreateAuctionDTo, Auction>().ForMember(d => d.Item, o => o.MapFrom(s => s));
        CreateMap<CreateAuctionDTo, Item>();
    }
}