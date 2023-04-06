using Enrollment.Management.Students.Infrastructure.Context;
using Enrollment.Management.Students.Infrastructure.Context.Entities;
using Enrollment.Management.Students.Infrastructure.Interfaces;

namespace Enrollment.Management.Students.Infrastructure.Repositories
{
    public class StudentsRepository : Repository<Alunos>, IStudentsRepository
    {
        public StudentsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
