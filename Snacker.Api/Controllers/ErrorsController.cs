using System.Data;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Snacker.Api.Controllers;

    
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<ExceptionHandlerFeature>()?.Error;

            var (statusCode,message ) = exception switch 
            {
             IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),   
             =>(StatusCodes.Status500InternalServerError, "An unexpected error occured"),
            };
            return Problem(statusCode : statusCode , title : message ); 
        }
    }
