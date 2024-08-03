using AutoMapper;
using EmployeeManagementAPI.Dtos;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        }
    }
}
