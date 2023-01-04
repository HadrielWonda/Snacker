using System.Reflection;
using System.Net.Http.Headers;
using Microsoft.Extensions.Dependencyinjection;
using Snacker.Application.Services.DependencyInjection;
using Snacker.Application.Authentication.Commands.Register;
using Snacker.Application.Common.Behaviours;
using MediatR.Microsoft.Extensions.DependencyInjection;
using MediatR;
using OneOf;

namespace Snacker.Application;

public static class DependencyInjection
{
public static IServiceCollection AddApplication(this IServiceCollection services)
{
  services.AddMediatR(typeof(DependencyInjection).Assembly);
  services.AddScoped(
  typeof(IPipelineBehaviour<,>),
  typeof(ValidationBehaviour<,>)
  );
  //services.AddScoped<IValidator<RegisterCommand>,RegisterCommandValidator>(); replaced by
  services.AddValidatorsFromAssembly(Assembly.GetExcecutingAssembly());
    return services;
}
}