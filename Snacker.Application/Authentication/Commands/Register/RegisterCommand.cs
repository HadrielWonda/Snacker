using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneOf;
using MediatR;
using Snacker.Application.Authentication.Common;

namespace Snacker.Application.Authentication.Commands.Register;

    public record RegisterCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest OneOf<IError,AuthenticationResult>;
        
    
