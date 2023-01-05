using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

namespace Snacker.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{

private readonly JwtSettings _jwtSettings

private readonly IDateTimeProvider _dateTimeProvider

public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtOptions)
{
    _dateTimeProvider = dateTimeProvider;
    _jwtSettings = jwtOptions.Value;
}

public string GenerateToken(User user)
{
    var signingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Secret)
        ),
        SecurityAlgorithms.HmacSha256
    );
    var claims = _new[]
    {
        new Claiim(JwtRegisteredClaimNames.Sub,User.Id.ToString()),
        new Claiim(JwtRegisteredClaimNames.GivenName,User.FirstName),
        new Claiim(JwtRegisteredClaimNames.FamilyName,User.LastName),
        new Claiim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        
    };

    var securityToken = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
        claims: claims,
        signingCredentials : signingCredentials
    );


    return new JwtSecurityTokenHandler().WriteToken(securityToken);
    //throw new NotImplementedException();
}

}
 