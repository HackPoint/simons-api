using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.ArEvents.Queries.GetArEvents; 

public class ArEventDto : IMapFrom<ArEvent> {
    public Guid DebtId { get; init; }
    public string? Content { get; init; }
    public string? Browser { get; init; }
    public DateTime Timestamp { get; init; }
    public void Mapping(Profile profile) {
        profile.CreateMap<ArEvent, ArEventDto>();
    }
}