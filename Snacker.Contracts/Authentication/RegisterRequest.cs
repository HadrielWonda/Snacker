sing System;
using System.Linq;

namespace Snacker.Contracts.Authentication;

public record RegisterRequest(
    string firstName,
    string lastName,
    string email,
    string password,

)
