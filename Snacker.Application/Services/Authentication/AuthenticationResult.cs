namespace Snacker.Application.Services.Authentication;


public record AuthenticationResult(
    User user,
    string token
);