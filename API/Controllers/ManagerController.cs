using API.Domain;
using API.DTO;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ManagerController : BaseApiController
    {
        private readonly IManagerService _managerService;
        private readonly IMapper _mapper;

        public ManagerController(IManagerService managerService, IMapper mapper)
        {
            _mapper = mapper;
            _managerService = managerService;
        }

        [HttpPost]
        public async Task<ActionResult<Manager>> AddManagerAsync(ManagerDTO managerDTO)
        {
            return Ok(await _managerService.AddManagerAsync(managerDTO));
        }
    }
}