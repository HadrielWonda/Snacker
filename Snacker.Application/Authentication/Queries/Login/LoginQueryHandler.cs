using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Application.Authentication.Queries.Login;

    public class LoginQueryHandler :IRequestHandler<LoginQuery,OneOf<AuthenticationResult,IError>>
    {
       private readonly IJwtTokenGenerator _jwtTokenGenerator
       private readonly IUserRepository _userRepository 

       public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository )
       {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository; 
       }

        public async Task<OneOf<AuthenticationResult,IError>> Handle(LoginQuery query, CancellationToken cancellationToken )
        {
         // 1.Verify User Existence
       if (_userRepository.GetUserByEmail(query.Email)is not User user)
       {
        throw new Exception("User with this mail does not exist");
       }
      //2. Verify that password is correct
       if (user.Password != query.Password)
       {
        throw new Exception("Incorrect Password");
       }
      //3. Create JWT Token
    var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
       throw new NotImplementedException();

        }

