using Enrollment.Management.Registration.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Management.Registration.Domain.Interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<MatriculasDto>> GetAllRegistrationsAsync();
        Task<MatriculasDto> GetRegistrationByIdAsync(int id);
        Task<bool> CreateRegistrationAsync(MatriculasDto matriculasDto);
        Task<bool> UpdateRegistrationAsync(MatriculasDto matriculasDto);
        Task<bool> DeleteRegistrationAsync(int id);
    }
}
