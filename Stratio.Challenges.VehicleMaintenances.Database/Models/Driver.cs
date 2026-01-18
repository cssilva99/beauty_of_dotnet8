public class Driver
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string TachographCardNumber { get; set; } = string.Empty;
}

public class TripSession
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid DriverId { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    // Navigation Properties(Lazy Loading or Eager Loading)
    public Vehicle Vehicle { get; set; } = null!;
    public Driver Driver { get; set; } = null!;
}
