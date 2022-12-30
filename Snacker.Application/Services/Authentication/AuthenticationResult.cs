namespace Snacker.Application.Services.Authentication;


public record AuthenticationResult(
    guid id,
    string firstName,
    string lastName,
    string email,
    string token
)