public class Role 
{
    public int Id { get; set; }
    public string Name { get; set; } // "Admin", "Contributor", "Reader" 
  
    // This relates the permissions to the role
    public ICollection<RolePermission> RolePermissions { get; set; }

}
