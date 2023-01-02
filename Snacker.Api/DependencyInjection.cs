using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Snacker.Api;

public static class DependencyInjection
{
public static IServiceCollection.AddPresentation(this IServiceCollection services)
{
  services.AddMappings();
  services.AddControllers();
  services.AddSingleton<ProblemDetailsFactory,SnackerProblemDetailsFactory>();

   return services;
}
}