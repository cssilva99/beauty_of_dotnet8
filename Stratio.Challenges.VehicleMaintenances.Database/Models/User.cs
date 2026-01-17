namespace Stratio.Challenges.VehicleMaintenance.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    // A user might belong to several Organization's
    // and have a different role in each Organization
    public ICollection<UserOrganizationRole> OrganizationRoles { get; set; } = new List<UserOrganizationRole>();
}
