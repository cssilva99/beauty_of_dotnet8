public enum Severity { Info, Warning, Critical }

public class DtcEvent
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }

    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty; // Ex: P0420

    public string EcuSource { get; set; } = string.Empty; // Ex: Brake System, Engine Control
    public Severity Severity { get; set; }
    public bool IsActive { get; set; }
    
    public DateTime Timestamp { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
}
