
using BusinessLogicLayer.Services.Concrete;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLogicLayer.Utilities.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)

    {
        services.AddControllersWithViews();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ISubCategoryService, SubCategoryManager>();

        services.AddAuthentication();
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
