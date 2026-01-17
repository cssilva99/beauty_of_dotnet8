public abstract class TenantEntity 
{
    public int Id { get; set; }
    public Guid OrganizationId { get; set; } // "TenantId"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
