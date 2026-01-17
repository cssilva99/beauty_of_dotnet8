public class UserOrganizationRole : TenantEntity
  // This Class inherits from TenantEntity Abstract Class
  // It will inherit the OrganizationId from the TenantEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}
