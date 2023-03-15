using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace EmployeeManagementt.JwtToken
{
    internal class TokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage httpRequestMessage, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!httpRequestMessage.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode httpStatusCode;
            string token;
            //determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
                return base.SendAsync(request, cancellationToken);
            }
            try
            {
                const string sec = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
                var now = DateTime.UtcNow;
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "https://localhost:44397",
                    ValidIssuer = "https://localhost:44397",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                System.Web.HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken); return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }
            //- this line would return correct CORS header.- credit to 
            //return base.SendAsync(request, cancellationToken);            
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(httpStatusCode) { });
        }
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }

}