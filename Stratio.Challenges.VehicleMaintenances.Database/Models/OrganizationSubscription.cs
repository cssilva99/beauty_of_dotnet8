namespace Stratio.Challenges.VehicleMaintenance.Entities;

public class OrganizationSubscription : TenantEntity
{
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; } = null!;

    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    
    // Payment Method (Ex: "CreditCard", "BankTransfer")
    public string PaymentMethod { get; set; } = "BankTransfer";
    
    public bool IsAutoRenew { get; set; } = true;
}
