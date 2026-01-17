using Microsoft.EntityFrameworkCore;
namespace Stratio.Challenges.VehicleMaintenances.Api

public interface ITenantService
{
    Guid GetTenantId();
}
