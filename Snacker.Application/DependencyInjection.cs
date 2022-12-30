using Microsoft.Extensions.Dependencyinjection.Abstractions;
using Snacker.Application.Services.DependencyInjection;

namespace Snacker.Application;

public static class DependencyInjection
{
public static IServiceCollection.AddApplication(this IServiceCollection services)
{
    services.AddScoped <IAuthenticationService, AuthenticationService>();
    return services;
}
}