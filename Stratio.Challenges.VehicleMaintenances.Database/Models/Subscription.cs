namespace Stratio.Challenges.VehicleMaintenance.Entities;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Ex: "Premium Plan"
    public decimal Price { get; set; }
    
    // Different currencies could be supported
    public string CurrencyCode { get; set; } = "EUR"; // ISO Code: EUR, USD, etc.
    
    public int MaxUsers { get; set; } // Just like Confluence for example, there is a limit of users
    public bool IsActive { get; set; } = true;
}
