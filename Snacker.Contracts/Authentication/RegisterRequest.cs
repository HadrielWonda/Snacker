using System;
using System.Linq;

namespace Snacker.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,

);
