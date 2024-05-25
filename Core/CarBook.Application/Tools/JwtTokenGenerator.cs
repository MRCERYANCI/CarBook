using CarBook.Application.Dtos;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult getCheckAppUserQueryResult)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(getCheckAppUserQueryResult.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, getCheckAppUserQueryResult.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, getCheckAppUserQueryResult.Id.ToString()));
            if (!string.IsNullOrWhiteSpace(getCheckAppUserQueryResult.UserName))
            {
                claims.Add(new Claim("UserName", getCheckAppUserQueryResult.UserName));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiredate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudiance, claims: claims, notBefore: DateTime.UtcNow, expires: expiredate, signingCredentials: signinCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(tokenHandler.WriteToken(token), expiredate);
        }
    }
}
