using AutoMapper;
using Enrollment.Management.Students.Domain.Dtos;
using Enrollment.Management.Students.Domain.Interfaces;
using Enrollment.Management.Students.Infrastructure.Context.Entities;
using Enrollment.Management.Students.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Management.Students.Domain.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IMapper mapper, IStudentsRepository studentsRepository)
        {
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<IEnumerable<AlunosDto>> GetAllStudentsAsync()
        {
            var result = await _studentsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlunosDto>>(result);
        }

        public async Task<AlunosDto> GetStudentByIdAsync(int id)
        {
            var result = await _studentsRepository.GetByIdAsync(id);
            return _mapper.Map<AlunosDto>(result);
        }

        public async Task<bool> CreateStudentAsync(AlunosDto alunosDtos)
        {
            var productEntity = _mapper.Map<Alunos>(alunosDtos);

            var result = await _studentsRepository.InsertAsync(productEntity);

            return result;
        }

        public async Task<bool> UpdateStudentAsync(AlunosDto alunosDtos)
        {
            var productEntity = _mapper.Map<Alunos>(alunosDtos);

            var result = await _studentsRepository.UpdateAsync(productEntity);

            return result;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var product = await _studentsRepository.GetByIdAsync(id);

            if (product is null)
                return false;

            var result = await _studentsRepository.DeleteAsync(product);

            return result;
        }
    }
}
