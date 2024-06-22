using Microsoft.EntityFrameworkCore;
using TodoMiniAPI.Data;
using TodoMiniAPI.Services;

namespace TodoMiniAPI.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            // build memory db
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoDB"), ServiceLifetime.Singleton);

            // services
            services.AddSingleton<ICategoryService, CategoryService>();

            return services;
        }
    }
}
