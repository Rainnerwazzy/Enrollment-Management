using Enrollment.Management.Courses.Infrastructure.Context;
using Enrollment.Management.Courses.Infrastructure.Context.Entities;
using Enrollment.Management.Courses.Infrastructure.Interfaces;

namespace Enrollment.Management.Courses.Infrastructure.Repositories
{
    public class CoursesRepository : Repository<Cursos>, ICoursesRepository
    {
        public CoursesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
