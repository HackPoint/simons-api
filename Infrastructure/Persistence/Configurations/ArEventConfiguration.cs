using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations; 

public class ArEventConfiguration  : IEntityTypeConfiguration<ArEvent> {
    public void Configure(EntityTypeBuilder<ArEvent> builder) {
        builder.Property(cfg => cfg.CreatedAt)
            .HasColumnName("created_at")
            .HasConversion<DateTime>();
        
        builder.Property(cfg => cfg.Timestamp)
            .HasColumnName("timestamp")
            .IsRequired();
        
        builder.Property(cfg => cfg.DebtId)
            .HasColumnName("dca_id")
            .IsRequired();
        
        builder.Property(cfg => cfg.Browser)
            .HasColumnName("browser")
            .IsRequired();
        
        builder.Property(cfg => cfg.Content)
            .HasColumnName("content")
            .IsRequired();
    }
}