using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Activities;
using Application.Core;

namespace API.Extensions
{
    /// <summary>
    /// This class is used to add application services to the service collection.
    /// This is done to keep the code in the API/Program.cs file clean.
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// This method is used to add application services to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                                IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}