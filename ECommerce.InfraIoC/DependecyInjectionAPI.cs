using ECommerce.Application.Interfaces;
using ECommerce.Application.Mappings;
using ECommerce.Application.Services;
using ECommerce.Domain.Account;
using ECommerce.Domain.Interfaces;
using ECommerce.InfraData.Context;
using ECommerce.InfraData.Identity;
using ECommerce.InfraData.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.InfraIoC
{
    public static class DependecyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.
            UseSqlServer(configuration.
            GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            //Domain
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            //Service
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            var handler = AppDomain.CurrentDomain.Load("ECommerce.Application");
            services.AddMediatR(handler);

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>().
                AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            return services;
        }
    }
}
