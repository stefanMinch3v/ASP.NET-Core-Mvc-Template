namespace AspNetCoreMvcTemplate.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using System.Linq;
    using System.Reflection;

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// auto mapping all services (IExampleService to ExampleService) using Scoped extension
        /// </summary>
        /// <param name="services">interface IServiceCollection</param>
        /// <returns>returns IServiceCollection</returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => services.AddScoped(s.Interface, s.Implementation));

            return services;
        }
    }
}
