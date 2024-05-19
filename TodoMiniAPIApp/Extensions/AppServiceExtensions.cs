using Microsoft.EntityFrameworkCore;
using TodoMiniAPIApp.Data;

namespace TodoMiniAPIApp.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            //build memory db
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoDB"));

            //scoped
            //TODO?

            return services;
        }
    }
}
