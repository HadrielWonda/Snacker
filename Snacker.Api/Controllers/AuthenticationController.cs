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


[ApiController]
[Route ("auth")]
[ErrorHandlingMiddleware]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator
   
   public AuthenticationController(ISender _mediator)
   {
    _mediatR = mediatR;
   }
    [HttpPost ("register")]
    
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email,request.Password);
        OneOf<AuthenticationResult, IError> authResult = await _mediator.Send(command);
        
        return authResult.Match(
            authResult =>Ok(MapAuthResult(authResukt)),
            errors => Problem(errors);
        );

        }

        
        
    };

    
     [HttpPost("login")]
    
    public async Task<IActionResult> Login(LoginRequest request)
    {
         var query = newLoginQuery(request.Email,request.Password);
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

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.User.Password
        );
    }
    


