using System.Security.Cryptography;
using API.Data.Interfaces;
using API.Domain;
using API.DTO;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }
        public async Task<Manager> AddManagerAsync(ManagerDTO managerDTO)
        {
            var manager = _mapper.Map<Manager>(managerDTO);

            using var hmac = new HMACSHA512();

            manager.Username = managerDTO.Username.ToLower();
            manager.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(managerDTO.Password));
            manager.PasswordSalt = hmac.Key;

            var result = await _managerRepository.AddAsync(manager);

            return result;
        }

        public async Task<Manager> GetManagerByUsername(string name)
        {
            return await _managerRepository.GetManagerByUsername(name);
        }
    }
}