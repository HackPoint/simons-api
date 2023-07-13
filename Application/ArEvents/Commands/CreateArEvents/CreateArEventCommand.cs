using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.ArEvents.Commands.CreateArEvents;

public record CreateArEventCommand : IRequest<int> {
    public Guid DebtId { get; init; }
    public string? Content { get; init; }
    public string? Browser { get; init; }
}

public class CreateArEventCommandHandler : IRequestHandler<CreateArEventCommand, int> {
    private readonly IApplicationDbContext _dbContext;
    public CreateArEventCommandHandler(IApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }
    public async Task<int> Handle(CreateArEventCommand request, CancellationToken cancellationToken) {
        var arEvent = new ArEvent {
            Id = default,
            Browser = request.Browser,
            Content = request.Content,
            DebtId = request.DebtId
        };
        _dbContext.Events.Add(arEvent);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return arEvent.Id;
    }
}