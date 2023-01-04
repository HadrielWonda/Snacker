using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using Snacker.Application.Authentication.Commands.Register;
using OneOf;

namespace Snacker.Application.Common.Behaviours;

    public class ValidationBehaviour<TRequest , TResponse> : IPipelineBehaviour<TRequest , TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse :IError 
    {
        private readonly IValidator<TRequest>? _validator

        public ValidationBehaviour(IValidator<TRequest>? validator = null)
        {
         _validator = validator;
        }

        public async Task<OneOf<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {   

            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request,cancellationToken);

             if (validationResult.IsInvalid)
             {
                return await next();
             }

             var errors = validationResult.Errors
             .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName, 
                validationFailure.ErrorMessage))
             .ToList();
            
            return (dynamic)errors;
        }
    }
