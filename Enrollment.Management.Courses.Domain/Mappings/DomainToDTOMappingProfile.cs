using AutoMapper;
using Enrollment.Management.Courses.Domain.Dtos;
using Enrollment.Management.Courses.Infrastructure.Context.Entities;

namespace Enrollment.Management.Courses.Domain.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Cursos, CursosDto>().ReverseMap();
        }
    }
}
