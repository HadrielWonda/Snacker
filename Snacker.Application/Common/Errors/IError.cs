using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Application.Common.Errors;

    public interface IError
    {
        public HttpStatusCode StatusCode { get; }

        public string ErrorMessage { get; }
    }