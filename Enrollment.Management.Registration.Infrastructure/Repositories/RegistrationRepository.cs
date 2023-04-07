using Enrollment.Management.Registration.Infrastructure.Context;
using Enrollment.Management.Registration.Infrastructure.Context.Entities;
using Enrollment.Management.Registration.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Management.Registration.Infrastructure.Repositories
{
    public class RegistrationRepository : Repository<Matriculas>, IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Matriculas> _entities;
        public RegistrationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _entities = context.Set<Matriculas>();
        }

        public override async Task<IEnumerable<Matriculas>> GetAllAsync() => await _entities.AsNoTracking()
            .Include(c => c.Aluno)
            .Include(c => c.Curso).ToListAsync();

        public override async Task<Matriculas> GetByIdAsync(int? id) =>
            await _entities.AsNoTracking()
            .Include(c => c.Aluno)
            .Include(c => c.Curso).SingleOrDefaultAsync(s => s.Id == id);

        public override async Task<bool> InsertAsync(Matriculas entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public override async Task<bool> UpdateAsync(Matriculas entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public override async Task<bool> DeleteAsync(Matriculas entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
