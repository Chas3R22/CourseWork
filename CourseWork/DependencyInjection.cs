using CourseWork.Application.Services.Implementations;
using CourseWork.Application.Services.Interfaces;
using CourseWork.Persistence.Repositories.Implementations;
using CourseWork.Persistence.Repositories.Interfaces;

namespace CourseWork.Api
{
    public static class DependencyInjection
    {
        public static void CustomServices(this IServiceCollection services)
        {
            // services.AddScoped<ICountryRepository, CountryRepository>();
            // services.AddScoped<IIndustryRepository, IndustryRepository>();
            // services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            // 
            // services.AddScoped<ICountryService, CountryService>();
        }
    }
}
