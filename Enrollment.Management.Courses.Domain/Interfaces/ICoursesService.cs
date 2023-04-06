using Enrollment.Management.Courses.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enrollment.Management.Courses.Domain.Interfaces
{
    public interface ICoursesService
    {
        Task<IEnumerable<CursosDto>> GetAllCoursesAsync();
        Task<CursosDto> GetCourseByIdAsync(int id);
        Task<bool> CreateCourseAsync(CursosDto cursosDto);
        Task<bool> UpdateCourseAsync(CursosDto cursosDto);
        Task<bool> DeleteCourseAsync(int id);
    }
}
