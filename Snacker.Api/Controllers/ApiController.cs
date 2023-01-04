using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Snacker.Api.Controllers;

    [ApiController]
    
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {

            if (errors.Count is 0)
            {
                return Problem();
            }

            if (errors.All(errors => error.Type == ErrorType.Validation))
            {
              return ValidationProblem(errors);
            }

          //Use ifs for custom logic {domain 23}

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];

           return Problem();
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
              var modelStateDictionary = new modelStateDictionary();

                foreach (var error in errors)
                {
                    modelStateDictionary.AddModelError(
                        error.Code,
                        error.Description

                    );
                }
                return ValidationProblem(modelStateDictionary);
        }

        private IActionResult Problem(Error error)
        {
             var statusCode = error.Type switch 
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                => StatusCodes.Satus500InternalServerError,
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
