using AutoMapper;
using Enrollment.Management.Courses.Domain.Dtos;
using Enrollment.Management.Courses.Domain.Interfaces;
using Enrollment.Management.Courses.Infrastructure.Context.Entities;
using Enrollment.Management.Courses.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enrollment.Management.Courses.Domain.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;

        public CoursesService(IMapper mapper, ICoursesRepository coursesRepository)
        {
            _mapper = mapper;
            _coursesRepository = coursesRepository;
        }

        public async Task<IEnumerable<CursosDto>> GetAllCoursesAsync()
        {
            var result = await _coursesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CursosDto>>(result);
        }

        public async Task<CursosDto> GetCourseByIdAsync(int id)
        {
            var result = await _coursesRepository.GetByIdAsync(id);
            return _mapper.Map<CursosDto>(result);
        }

        public async Task<bool> CreateCourseAsync(CursosDto cursosDto)
        {
            var productEntity = _mapper.Map<Cursos>(cursosDto);

            var result = await _coursesRepository.InsertAsync(productEntity);

            return result;
        }

        public async Task<bool> UpdateCourseAsync(CursosDto cursosDto)
        {
            var productEntity = _mapper.Map<Cursos>(cursosDto);

            var result = await _coursesRepository.UpdateAsync(productEntity);

            return result;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var product = await _coursesRepository.GetByIdAsync(id);

            if (product is null)
                return false;

            var result = await _coursesRepository.DeleteAsync(product);

            return result;
        }
    }
}
