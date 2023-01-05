using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Net.Cache;
using Microsoft.AspNetCore.Mvc;
using Snacker.Application.Authentication.Common;
using Snacker.Application.Services.Authentication.Commands;
using Snacker.Application.Services.Authentication.Queries;
using Snacker.Application.Services.Authentication.With;
using System.Threading;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneOf;


namespace Snacker.Api.Controllers;



[Route ("auth")]
[AllowAnonymous]

public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
   
   public AuthenticationController(ISender mediator, IMapper mapper )
   {
    _mediator = mediator;
    _mapper = mapper;
   }
    [HttpPost ("register")]
    
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        OneOf<AuthenticationResult, IError> authResult = await _mediator.Send(command);
        
        return authResult.Match(
            authResult =>Ok(_mapper.Map<AuthenticationResponse>()(authResukt)),
            errors => Problem(errors);
        );

        }

        
        
    };

    
     [HttpPost("login")]
    
    public async Task<IActionResult> Login(LoginRequest request)
    {
         var query = _mapper.Map<LoginQuery>(request);
         var authResult = await _mediator.Send(query);
       if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
       {
        return Problem(
            statusCode: StatusCode.Status402Unauthorized,
            title:authResult.FirstError.Description
        );
       }

       return authResult.Match(
        authResult => Ok(MapAuthResult(authResult)),
        error => Problem(errors)
       );
    }

   


