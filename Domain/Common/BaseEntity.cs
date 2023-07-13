using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common; 

public abstract class BaseEntity<TId> {
    [Column("id")]
    public required TId Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
}