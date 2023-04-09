using Enrollment.Management.Registration.Domain.Interfaces;
using Enrollment.Management.Registration.Domain.Mappings;
using Enrollment.Management.Registration.Domain.Services;
using Enrollment.Management.Registration.Infrastructure.Context;
using Enrollment.Management.Registration.Infrastructure.Interfaces;
using Enrollment.Management.Registration.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enrollment.Management.Registration.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<ISenderEmailService, SenderEmailService>();
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        }
    }
}
