using AuthorizationJwt;
using Microsoft.IdentityModel.Tokens;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Authorization
{
    public class AuthJwtManager : IAuthJwtManager
    {
        public AuthJwtModel GenerateToken(UserDtoModel user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var expireDate = DateTime.Now.AddSeconds(JwtConfigure.Current.TokenLifeTime);

            var token = new JwtSecurityToken
            (JwtConfigure.Current.Issuer,
             JwtConfigure.Current.Audience,
             claims, 
             expires: expireDate,
             signingCredentials: new SigningCredentials(
                        JwtConfigure.Current.SymmetricSecurityKey,
                        JwtConfigure.Current.SigningAlgorithm));

            string tokenResult = new JwtSecurityTokenHandler().WriteToken(token);

            var jwtModel = new AuthJwtModel()
            {
                UserId = user.Id.ToString(),
                AccessTokenType = "Bearer",
                AccessToken = tokenResult,
                Expires = expireDate                
            };

            return jwtModel;
        }
    }
}
