namespace Stratio.Challenges.VehicleMaintenance.Entities;

public class Organization : TenantEntity
{
    public string Name { get; set; } = string.Empty;
    
    // Campos para B2B e Impostos
    public string? VatNumber { get; set; } // NIF da empresa
    public string? BillingEmail { get; set; }
    public string? Address { get; set; }
    
    // This a boolean to flag if a given Client Company has passed an Intra-community IVA
    public bool IsVatValidated { get; set; } = false;

    // Entity Relations
    public ICollection<UserOrganizationRole> UserRoles { get; set; } = new List<UserOrganizationRole>();
}
