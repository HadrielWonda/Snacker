using System.Net.Http.Headers;
using Microsoft.Extensions.Dependencyinjection;
using Snacker.Application.Services.DependencyInjection;
using MediatR.Microsoft.Extensions.DependencyInjection;

namespace Snacker.Application;

public static class DependencyInjection
{
public static IServiceCollection.AddApplication(this IServiceCollection services)
{
  services.AddMediatR(typeof(DependencyInjection).Assembly);
    return services;
}
}