using System;
using System.Linq;

namespace Snacker.Contracts.Authentication;

public record LoginRequest(
    
    string email,
    string password,

)
