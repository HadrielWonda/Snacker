using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Dependencyinjection;
using Microsoft.Extensions.Options.ConfigurationExtensions;
using Snacker.Application.Common.Interfaces.Authentication;
using Snacker.Application.Common.Interfaces.Services;
using Snacker.Infrastructure.Authentication;
using Snacker.Infrastructure.Services;



namespace Snacker.Infrastructure;

public static class DependencyInjection
{
public static IServiceCollection.AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
{
    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
    services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
    services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
    return services;
}
}