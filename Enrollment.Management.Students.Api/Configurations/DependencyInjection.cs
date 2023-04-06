using Enrollment.Management.Students.Domain.Interfaces;
using Enrollment.Management.Students.Domain.Mappings;
using Enrollment.Management.Students.Domain.Services;
using Enrollment.Management.Students.Infrastructure.Context;
using Enrollment.Management.Students.Infrastructure.Interfaces;
using Enrollment.Management.Students.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enrollment.Management.Students.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        }
    }
}
