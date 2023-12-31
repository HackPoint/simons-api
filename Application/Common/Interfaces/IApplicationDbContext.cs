using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext {
    DbSet<ArEvent> Events { get; }

    Task<int> SaveChangesAsync(CancellationToken token);
}