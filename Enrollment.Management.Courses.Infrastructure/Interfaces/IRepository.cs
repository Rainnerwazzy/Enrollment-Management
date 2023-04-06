using Enrollment.Management.Courses.Infrastructure.Context.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enrollment.Management.Courses.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
