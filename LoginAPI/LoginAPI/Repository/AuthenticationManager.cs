using LoginAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
    public class AuthenticationManager : IAuthenticationManager
    {
        FlightManagementSystemContext _context = new FlightManagementSystemContext();

        private readonly string tokenKey;
        public AuthenticationManager(string TokenKey)
        {

            this.tokenKey = TokenKey;


        }

        public string Authenticate(string username, string password)
        {
            if (!_context.Userdetails.Any(u => u.Username == username && u.Password == password))
            {
                return null;

            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public int GetUserid(string username)
        {
            int userId = _context.Userdetails.Single(user => user.Username == username).Userid;
            return userId;
        }

        
    }
}
