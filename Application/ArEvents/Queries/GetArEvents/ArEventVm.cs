using Domain.Entities;

namespace Application.ArEvents.Queries.GetArEvents; 

public class ArEventVm {
    public IReadOnlyCollection<ArEventDto> Lists { get; init; } = Array.Empty<ArEventDto>();
}