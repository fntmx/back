using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bmwadforth.Common.Configuration;
using Bmwadforth.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Bmwadforth.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly AuthenticationConfiguration _authenticationConfiguration;
    
    public AuthenticationService(IConfiguration configuration)
    {
        _authenticationConfiguration = new AuthenticationConfiguration();
        configuration.Bind("Authentication", _authenticationConfiguration);
    }
    
    public JwtSecurityToken GenerateToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfiguration.Key));

        var token = new JwtSecurityToken(
            issuer: _authenticationConfiguration.Issuer,
            audience: _authenticationConfiguration.Audience,
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
    
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool ValidateHash(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}