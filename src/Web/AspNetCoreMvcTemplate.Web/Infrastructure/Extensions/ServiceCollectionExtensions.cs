namespace AspNetCoreMvcTemplate.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Infrastructure.Filters;
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
            var types = Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                });

            foreach (var type in types)
            {
                var attributes = type.Interface.CustomAttributes;

                var isScoped = attributes.Any(attr => attr.AttributeType == typeof(ScopedServiceAttribute));
                var isSingleton = attributes.Any(attr => attr.AttributeType == typeof(SingletonServiceAttribute));
                var isTransient = attributes.Any(attr => attr.AttributeType == typeof(TransientServiceAttribute));

                if (isScoped)
                {
                    services.AddScoped(type.Interface, type.Implementation);
                }
                else if (isSingleton)
                {
                    services.AddSingleton(type.Interface, type.Implementation);
                }
                else if (isTransient)
                {
                    services.AddTransient(type.Interface, type.Implementation);
                }
            }

            return services;
        }
    }
}
