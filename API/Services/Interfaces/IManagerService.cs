using API.Domain;
using API.DTO;

namespace API.Services.Interfaces
{
    public interface IManagerService
    {
        public Task<Manager> AddManagerAsync(ManagerDTO manager);
    }
}