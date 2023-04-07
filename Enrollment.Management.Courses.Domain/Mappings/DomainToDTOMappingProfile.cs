using AutoMapper;
using Enrollment.Management.Courses.Domain.Dtos;
using Enrollment.Management.Courses.Infrastructure.Context.Entities;

namespace Enrollment.Management.Courses.Domain.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Cursos, CursosDto>().ForMember(x => x.ListDisciplinas, opt => opt.MapFrom(src => src.Disciplina.Split(';')));
            CreateMap<CursosDto, Cursos>().ForMember(x => x.Disciplina, opt => opt.MapFrom(src => string.Join(";", src.ListDisciplinas))); 
        }
    }
}
