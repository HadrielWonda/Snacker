using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Application.Authentication.Common;

    public record AuthenticationResult(User User,string Token);
