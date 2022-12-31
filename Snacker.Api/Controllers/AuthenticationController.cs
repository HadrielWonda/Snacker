using Microsoft.AspNetCore.Mvc;
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
    private readonly IAuthenticationService _authenticationService
    [HttpPost ("register")]
    
    public IActionResult Register(RegisterRequest request)
    {
        OneOf<AuthenticationResult, IError> registerResult = _authenticationService.Register(request.firstName,request.lastName,request.email,request.password);
        
        if (registerResult.IsT0)
        {
            
        
        var authResult = registerResult.AsT0;
        var response = new AuthenticationResponse(
        authResult.User.id,
        authResult.User.firstName,
        authResult.User.lastName,
        authResult.User.email,
        authResult.token

        return Ok(response);
        );

        }

        return Problem((int)statusCode : StatusCodes.Status409Conflict, title :"Email already in use!")
        
    }


     [HttpPost("login")]
    
    public IActionResult Login(LoginRequest request)
    {
         var authResult = _authenticationService.Login(request.email,request.password);
         var response = new AuthenticationResponse(
         authResult.User.id,
         authResult.User.firstName,
         authResult.User.lastName,
         authResult.User.email,
         authResult.token)
        return Ok(response);

        return Ok(request);
    }
    


}