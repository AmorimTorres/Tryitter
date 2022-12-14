using Microsoft.IdentityModel.Tokens;
using Rede_Social_Da_Galera___Tryitter.Constants;
using Rede_Social_Da_Galera___Tryitter.Migrations;
using Rede_Social_Da_Galera___Tryitter.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rede_Social_Da_Galera___Tryitter.Services
{
    public class TokenGenerator
    {
        public string Generate(Student student)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(student),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
                Expires = DateTime.Now.AddDays(1)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        static ClaimsIdentity AddClaims(Student student)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("StudentId", student.StudentId.ToString()));
            return claims;
        }
    }
}
