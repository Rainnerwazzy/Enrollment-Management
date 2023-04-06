using AutoMapper;
using Enrollment.Management.Students.Domain.Dtos;
using Enrollment.Management.Students.Infrastructure.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enrollment.Management.Students.Domain.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Alunos, AlunosDto>().ReverseMap();
        }
    }
}
