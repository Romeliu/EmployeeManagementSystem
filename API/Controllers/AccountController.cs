using System.Security.Cryptography;
using System.Text;
using API.Domain;
using API.DTO;
using API.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IManagerService _managerService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(IEmployeeService employeeService, IManagerService managerService, ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _employeeService = employeeService;
            _managerService = managerService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            User user = (await _employeeService.GetEmployeesByNameAsync(loginDTO.Username)).FirstOrDefault();

            if (user == null)
            {
                user = await _managerService.GetManagerByUsername(loginDTO.Username);
                if(user == null)
                    return Unauthorized("invalid username");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (user.PasswordHash[i] != computedHash[i]) return Unauthorized("invalid password");
            }

            return new UserDTO
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user),
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }
    }
}