using System.Threading;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneOf;
using MediatR;
using Snacker.Application.Services.Authentication.Commands;

namespace Snacker.Application.Authentication.Commands.Register;

    public class RegisterCommandHandler :IRequestHandler<RegisterCommand,OneOf<AuthenticationResult,IError>>
    {
       private readonly IJwtTokenGenerator _jwtTokenGenerator
       private readonly IUserRepository _userRepository 

       public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository )
       {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository; 
       }

        public Task<OneOf<AuthenticationResult,IError>> Handle(RegisterCommand command, CancellationToken cancellationToken )
        {     
            await Task.CompletedTask; //this here and in LoginQueryhandler is dummy to fill-in for lack of async logic


              //1. Validate user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) != null)
        {
            return new DuplicateEmailError();
        }
        //2. Create user{generate unique Id} & Persist to ##
        var user = new User {
        FirstName= command.FirstName,
        LastName= command.LastName,
        Email=command.Email,
        Password=command.Password
         };

         _userRepository.Add(user);
        //3. Create JWT token
      
        var token =_jwtTokenGenerator.GenerateToken(user);

       return new AuthenticationResult(
        userId,
        firstName,
        lastName,
        email,
        token
       );
        }

    }
