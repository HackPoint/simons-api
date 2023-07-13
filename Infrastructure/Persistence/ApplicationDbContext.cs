using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext {
    private readonly IMediator _mediator;
    
    public DbSet<ArEvent> Events => Set<ArEvent>();

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator
    ) : base(options) {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}