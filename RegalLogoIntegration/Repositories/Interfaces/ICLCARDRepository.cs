using RegalLogoIntegration.Models;

namespace RegalLogoIntegration.Repositories.Interfaces
{
    public interface ICLCARDRepository
    {
        Task<IEnumerable<CLCARD>> GetAllAsync();
        Task<CLCARD> GetByIdAsync(int id);        
    }
}
