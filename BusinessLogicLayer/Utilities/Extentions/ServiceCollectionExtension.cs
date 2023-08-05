
using DataAccessLayer;
using DataAccessLayer.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Utilities.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAuthentication();
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        return services;
    }
}
