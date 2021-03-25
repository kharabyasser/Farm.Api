using Farm.Api.Interfaces;
using Farm.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Farm.Api.Configuration
{
    public static class IoCConfiguration
    { 
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            RegisterServices(services);
            RegisterType(services, "Seeder", typeof(ISeeder));
        }

        public static void RegisterServices(IServiceCollection services)
        {
            var assemblies = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in  assemblies)
            {
                if (type.IsClass && !type.IsSealed && !type.IsSubclassOf(typeof(BaseEntity)))
                {
                    var serviceInterface = type.GetInterfaces().FirstOrDefault();

                    if (serviceInterface != null)
                    {
                        var serviceModelType = serviceInterface.GetGenericArguments().FirstOrDefault();

                        if (serviceModelType != null && serviceModelType.BaseType == typeof(BaseEntity))
                        {
                            var serviceType = typeof(IService<>).MakeGenericType(serviceModelType);

                            if (serviceInterface == serviceType)
                            {
                                services.AddTransient(type);
                            }
                        }
                    }
                }
            }
        }

        public static void RegisterType(IServiceCollection services, string containName, Type type)
    {
        var seedersType = Assembly.GetExecutingAssembly().GetTypes()
          .Where(t => t.Name.Contains(containName) && t.GetInterfaces().Contains(type));

        foreach (var seeder in seedersType)
        {
            services.AddTransient(seeder);
        }
    }
    }
}
