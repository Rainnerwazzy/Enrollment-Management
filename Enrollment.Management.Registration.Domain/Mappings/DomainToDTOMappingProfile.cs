using AutoMapper;
using Enrollment.Management.Registration.Domain.Dtos;
using Enrollment.Management.Registration.Infrastructure.Context.Entities;

namespace Enrollment.Management.Registration.Domain.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            
            CreateMap<Cursos, CursosDto>().ForMember(x => x.ListDisciplinas, opt => opt.MapFrom(src => src.Disciplina.Split(';')));
            CreateMap<CursosDto, Cursos>().ForMember(x => x.Disciplina, opt => opt.MapFrom(src => string.Join(";", src.ListDisciplinas)));
            CreateMap<Alunos, AlunosDto>().ReverseMap();
            CreateMap<Matriculas, MatriculasDto>().ReverseMap();
        }
    }
}
