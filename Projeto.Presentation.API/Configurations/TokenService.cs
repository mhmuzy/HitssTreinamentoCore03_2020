using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto.Presentation.API.Configurations
{
    public class TokenService
    {
        //atribto..
        private readonly AppSettings appSettings;

        //contrutor para injeção de dependência
        public TokenService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        //criando um método para realizar a geração do TOKEN
        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                    (new Claim[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.Now.AddDays(1),
                //tempo de validade do TOKEN (1 dia)
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
