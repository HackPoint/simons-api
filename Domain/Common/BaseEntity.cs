using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common.Entities; 

public abstract class BaseEntity<TId> {
    [Column("id")]
    public required TId Id { get; set; }
}