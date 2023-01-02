using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Application.Authentication.Queries.Login;

    public record LoginQuery
    {
    (
        string Email,
        string Password
    ) : IRequest OneOf<IError,AuthenticationResult>;
        
    
    }
