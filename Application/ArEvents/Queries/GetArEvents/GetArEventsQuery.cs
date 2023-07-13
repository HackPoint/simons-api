using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ArEvents.Queries.GetArEvents;

public record GetArEventsQuery : IRequest<ArEventVm>;

public class GetArEventsQueryHandler : IRequestHandler<GetArEventsQuery, ArEventVm> {
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetArEventsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<ArEventVm> Handle(GetArEventsQuery request, CancellationToken cancellationToken) {
        return new ArEventVm {
            Lists = await _dbContext.Events
                .AsNoTracking()
                .ProjectTo<ArEventDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken)
        };
    }
}