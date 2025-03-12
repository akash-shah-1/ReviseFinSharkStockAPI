using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace api.Service;

public class TokenService : ITokenService
{
    //Step 1: Constructor Execution (Initialization)
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
    }

    public string CreateToken(AppUser user)
    {
        //Step 2: CreateToken Method Execution
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
        };
        
        //Step 3: Creating Signing Credentials : creds is an object that will sign the token to ensure it’s tamper-proof.
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        
        //Step 4: Creating Token Descriptor  : tokenDescriptor defines the token’s structure and metadata.
        var tokenDiscriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"]
        };
        
        //Step 5: Creating the Token : Creates an instance of JwtSecurityTokenHandler, a utility class for JWT operations. 
        var tokenHandler = new JwtSecurityTokenHandler();
        //Generates a SecurityToken object based on tokenDescriptor.
        var token = tokenHandler.CreateToken(tokenDiscriptor);
        
        //Step 6: Serializing the Token
        return tokenHandler.WriteToken(token);
    }
}