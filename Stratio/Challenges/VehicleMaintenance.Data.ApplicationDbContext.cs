using Microsoft.EntityFrameworkCore;
using Stratio.Challenges.VehicleMaintenance.Entities; // Here are the Organisation, Role, Permission, User Entities tetc
using Stratio.Challenges.VehicleMaintenance.Services; // Here lays ITenantService

namespace Stratio.Challenges.VehicleMaintenance.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ITenantService _tenantService;

        // Constructor that receives the user logged in
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, 
            ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
        }

        public DbSet<Organization> Organizations { get; set;}
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CONFIGURAÇÃO DO FILTRO GLOBAL
            // This is a filter that automatically applies to all LINQ queries
            // Exemplo: _context.Vehicles.ToList() passará a ser 
            // SELECT * FROM Vehicles WHERE OrganizationId = 'ID-DO-USER-LOGADO'
            modelBuilder.Entity<Vehicle>()
                .HasQueryFilter(v => v.OrganizationId == _tenantService.GetTenantId());

            modelBuilder.Entity<MaintenanceTask>()
                .HasQueryFilter(m => m.OrganizationId == _tenantService.GetTenantId());

            // Configuring the Permissions pivot table
            modelBuilder.Entity<UserOrganizationRole>()
                .HasKey(uor => new { uor.UserId, uor.OrganizationId, uor.RoleId });
        }
    }
}
