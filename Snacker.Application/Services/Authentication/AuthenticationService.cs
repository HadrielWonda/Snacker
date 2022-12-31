using System.Threading.Tasks;
using System.Reflection.Metadata;
using System;
namespace Snacker.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

        private readonly IJwtTokenGenerator _jwtTokenGenerator
        private readonly IUserRepository _userRepository 

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository _userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName,string lastName,string email,string password){
        //1. Validate user doesn't exist
        if (_userRepository.GetUserByEmail(email) != null)
        {
            return new AuthenticationResult(false, "This useer already exists,sign up with a different mail")
        }
        //2. Create user{generate unique Id} & Persist to ##
        var user = new User {
        FirstName=firstName,
        LastName=lastName,
        Email=email,
        Password=password
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

    public AuthenticationResult Login(string email,string password){
      // 1.Verify User Existence
       if (_userRepository.GetUserByEmail(email)is not User user)
       {
        throw new Exception("User with this mail does not exist")
       }
      //2. Verify that password is correct
       if (user.Password != password)
       {
        throw new Exception("Incorrect Password")
       }
      //3. Create JWT Token
    var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
       throw new NotImplementedException();
    }

       


}