using System.Security.AccessControl;
using System.Buffers;
using System.Net.Security;
using SystemAcl.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Dependencyinjection;
using Microsoft.Extensions.Options.ConfigurationExtensions;
using Snacker.Application.Common.Interfaces.Authentication;
using Snacker.Application.Common.Interfaces.Services;
using Snacker.Infrastructure.Authentication;
using Snacker.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;



namespace Snacker.Infrastructure;

public static class DependencyInjection
{
 public static IServiceCollection.AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
 {
    services.AddAuth(configuration);
    services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
    services.AddScoped<IUserRepository,UserRepository>();
    
    return services;
 }

 public static IServiceCollection.AddAuth(this IServiceCollection services,ConfigurationManager configuration)
 {
    var jwtSettings = new JwtSettings();
    configuration.Bind(JwtSettings.SectionName,jwtSettings);

    services.AddSingleton(Options.Create(JwtSettings));
    services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();

    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>options.TokenValidationParameters = 
              {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey =new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )  

              });

    return services;
 }

}