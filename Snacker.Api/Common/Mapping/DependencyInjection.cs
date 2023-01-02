using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Api.Common.Mapping;

    public static class DependencyInjection
    {
        
    public static IserviceCollection AddMappings(this IserviceCollection services)
    {
        //services.AddTransient<IRegister, AuthenticationMappingConfig>();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExcecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper,ServiceMapper>();

        return services;

    }

    }
