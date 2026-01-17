namespace Stratio.Challenges.VehicleMaintenances.Api.Services
{
    public interface IAuthService
    {
        // "Hello. I am an interface.
        // Please give me your credentials and I'll give you an empty token
        Task<string> Login(string email, string password);
    }
}
