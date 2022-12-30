using System;
using System.Linq;


namespace Snacker.Contracts.Authentication;

public record AuthenticationResponse(
    guid id,
    string firstName,
    string lastName,
    string email,
    string token,

)

    
