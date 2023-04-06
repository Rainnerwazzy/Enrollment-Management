using Enrollment.Management.Students.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Management.Students.Domain.Interfaces
{
    public interface IStudentsService
    {
        Task<IEnumerable<AlunosDto>> GetAllStudentsAsync();
        Task<AlunosDto> GetStudentByIdAsync(int id);
        Task<bool> CreateStudentAsync(AlunosDto alunosDtos);
        Task<bool> UpdateStudentAsync(AlunosDto alunosDtos);
        Task<bool> DeleteStudentAsync(int id);
    }
}
