using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class BaseArEvent : BaseEntity<int> {
    
}

[Table("events")]
public class ArEvent : BaseArEvent {
    public Guid DebtId { get; set; }
    public string? Content { get; set; }
    public string? Browser { get; set; }
    public DateTime Timestamp { get; set; }
}