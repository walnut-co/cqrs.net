using CQRS.Dispatcher;
using CQRS.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS
{
    public static class ServiceExtensions
    {
        public static void AddCQRS(this IServiceCollection services)
        {
            services.AddScoped<IRequestDispatcher, RequestDispatcher>();
        }
    }
}
