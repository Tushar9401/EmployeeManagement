using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;

namespace EmployeeManagementt.JwtToken
{
    public static class JwtToken
    {
        // KEY Generation same Key.
        private const string SECRET_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.
        GetBytes(SECRET_KEY)); public static string GenerateJwtToken(EmployeeLoginCredential loginCredential)
        {
            // Security length should be > 256 b
            //var issuer = "https://localhost:44397";
            var credentials = new /*Microsoft.IdentityModel.Tokens.*/SigningCredentials
 (SIGNING_KEY, SecurityAlgorithms.HmacSha256);
            // Create a token.
            var header = new JwtHeader(credentials);             //Expires in 1 minutes.
            DateTime expiry = DateTime.UtcNow.AddMinutes(3);
            int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;
            //Claims
            //Create a List of Claims, Keep claims name short    
            //var claims=new List<Claim>();
            //claims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString(),""));
            //claims.Add(new Claim("valid", "1", ""));
            //claims.Add(new Claim("userid", "1", ""));
            //claims.Add(new Claim("name", "Roshan", ""));             //Payload to contain  user information.
            var payload = new JwtPayload
            {
             {"sub",loginCredential.EmployeeID.ToString() },
             {"Name",loginCredential.EmployeeID.ToString() },
             {"email",loginCredential.EmployeeEmail },
             {"Roles",loginCredential.Role},
             {"exp",ts },
             {"iss","https://localhost:44397" },
             {"aud","https://localhost:44397" } };
            //Create Security Token object by giving required parameters    
            var secretToken = new JwtSecurityToken(header, payload);
            //var secretToken = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.AddMinutes(2),
            //    signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();             //Security Token
            var tokenString = handler.WriteToken(secretToken);
            Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token"); return tokenString;
        }
        }
    }