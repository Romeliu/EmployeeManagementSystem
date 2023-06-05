using API.Domain;
using API.DTO;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ManagerDTO, Manager>();
            CreateMap<AssignmentDTO, Assignment>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}