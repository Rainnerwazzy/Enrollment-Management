using AutoMapper;
using Enrollment.Management.Registration.Domain.Dtos;
using Enrollment.Management.Registration.Domain.Interfaces;
using Enrollment.Management.Registration.Infrastructure.Context.Entities;
using Enrollment.Management.Registration.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enrollment.Management.Registration.Domain.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IMapper _mapper;
        private readonly IRegistrationRepository _registrationsRepository;

        public RegistrationService(IMapper mapper, IRegistrationRepository studentsRepository)
        {
            _mapper = mapper;
            _registrationsRepository = studentsRepository;
        }

        public async Task<IEnumerable<MatriculasDto>> GetAllRegistrationsAsync()
        {
            var result = await _registrationsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MatriculasDto>>(result);
        }

        public async Task<MatriculasDto> GetRegistrationByIdAsync(int id)
        {
            var result = await _registrationsRepository.GetByIdAsync(id);
            var test = _mapper.Map<MatriculasDto>(result);
            return _mapper.Map<MatriculasDto>(result);
        }

        public async Task<bool> CreateRegistrationAsync(MatriculasDto alunosDtos)
        {
            var productEntity = _mapper.Map<Matriculas>(alunosDtos);

            var result = await _registrationsRepository.InsertAsync(productEntity);

            return result;
        }

        public async Task<bool> UpdateRegistrationAsync(MatriculasDto alunosDtos)
        {
            var productEntity = _mapper.Map<Matriculas>(alunosDtos);

            var result = await _registrationsRepository.UpdateAsync(productEntity);

            return result;
        }

        public async Task<bool> DeleteRegistrationAsync(int id)
        {
            var product = await _registrationsRepository.GetByIdAsync(id);

            if (product is null)
                return false;

            var result = await _registrationsRepository.DeleteAsync(product);

            return result;
        }
    }
}
