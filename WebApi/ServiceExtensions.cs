using Application.Interfaces;
using Application.Services;

namespace WebApi
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDepartmentAndRolesServices, DepartmentAndRolesServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
        }
    }
}
