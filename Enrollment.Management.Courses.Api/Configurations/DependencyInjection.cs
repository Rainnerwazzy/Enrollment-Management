using Enrollment.Management.Courses.Domain.Interfaces;
using Enrollment.Management.Courses.Domain.Mappings;
using Enrollment.Management.Courses.Domain.Services;
using Enrollment.Management.Courses.Infrastructure.Context;
using Enrollment.Management.Courses.Infrastructure.Interfaces;
using Enrollment.Management.Courses.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enrollment.Management.Courses.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<ICoursesService, CoursesService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        }
    }
}
