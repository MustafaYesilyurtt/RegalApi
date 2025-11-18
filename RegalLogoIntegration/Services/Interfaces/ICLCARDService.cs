using RegalLogoIntegration.Models;

namespace RegalLogoIntegration.Services.Interfaces
{
    public interface ICLCARDService
    {
        Task<IEnumerable<CLCARD>> GetAllAsync();
        Task<CLCARD> GetByIdAsync(int id);
    }
}
