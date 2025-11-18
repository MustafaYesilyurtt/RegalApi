using RegalLogoIntegration.Models;
using RegalLogoIntegration.Repositories.Interfaces;
using RegalLogoIntegration.Services.Interfaces;

namespace RegalLogoIntegration.Services
{
    public class CLCARDService:ICLCARDService
    {
        private readonly ICLCARDRepository _repository;

        public CLCARDService(ICLCARDRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CLCARD>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<CLCARD> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    }
}
