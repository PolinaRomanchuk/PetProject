using Data.SQL.Interfaces;
using Data.SQL.Repositories;
using System.Reflection;

namespace PetProject.Services.Helpers
{
    public class DiRegisterationHelper
    {
        public void RegisterAllRepositories(IServiceCollection services)
        {
            var dataInterfaceAssembly = Assembly.GetAssembly(typeof(IBaseRepository<>));
            var repositoriesAssembly = Assembly.GetAssembly(typeof(BaseRepository<>));

            dataInterfaceAssembly
                .GetTypes()
                .Where(
                    type => type.IsInterface
                        && type.GetInterfaces()
                            .Any(i =>
                                i.IsGenericType
                                && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>)
                            )
                    )
                .ToList()
                .ForEach(repositoryInterface =>
                {
                    services.AddScoped(repositoryInterface, serviceProvider =>
                    {
                        var constructorOfRepository =
                            repositoriesAssembly
                                .GetTypes()
                                .First(classType =>
                                    classType.IsClass
                                    && classType.GetInterfaces().Any(i => i == repositoryInterface))
                                .GetConstructors()
                                .OrderByDescending(x => x.GetParameters().Length)
                                .First();

                        return constructorOfRepository
                            .Invoke(constructorOfRepository
                                .GetParameters()
                                .Select(param => serviceProvider.GetService(param.ParameterType))
                                .ToArray());
                    });
                });
        }
        public void RegisterAllServices(IServiceCollection services)
        {
            var a = Assembly.GetAssembly(typeof(AuthService));
            var allInterfaceSrvice = a
                .GetTypes()
                .Where(t => t.Name.Contains("Service"))
                .Where(t => t.IsInterface);

            foreach (var t in allInterfaceSrvice)
            {
                var service = a.GetTypes()
                    .First(classType =>
                                    classType.IsClass
                                    && classType.GetInterfaces().Any(i => i == t));
                services.AddScoped(t, serviceProvider =>
                {
                    var constructorOfRepository =
                        service
                            .GetConstructors()
                            .FirstOrDefault(x => x.GetCustomAttributes().Any(i => i.GetType() == typeof(ScopedRegistrationAttribute)));
                    if (constructorOfRepository == null)
                    {
                        constructorOfRepository = service.GetConstructors().First();
                    }

                    return constructorOfRepository
                        .Invoke(constructorOfRepository
                            .GetParameters()
                            .Select(param => serviceProvider.GetService(param.ParameterType))
                            .ToArray());
                });
                
            }

        }


    }

}
