using Microsoft.AspNetCore.Mvc;

namespace Snacker.Api.Controllers;


[ApiController]
[Route "(auth)"]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    [HttpPost ("register")]
    
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.firstName,request.lastName,request.email,request.password);
        var response = new AuthenticationResponse(
        authResult.User.id,
        authResult.User.firstName,
        authResult.User.lastName,
        authResult.User.email,
        authResult.token
        );
        return Ok(response);
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