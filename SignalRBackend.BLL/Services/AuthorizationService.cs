using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SignalRBackend.BLL.DTO;
using SignalRBackend.BLL.Interfaces;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SignalRBackend.BLL.Services
{
    public class AuthorizationService: IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AuthenticatedResponseDTO Authorize(LoginDTO userdto)
        {
            if (userdto is null)
            {
                return null;
            }
            User user = _unitOfWork.User.FindByUserName(userdto.UserName);
            if (user != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return  new AuthenticatedResponseDTO {UserId = (Int32)user.Id, Token = tokenString, UserName =user.UserName};
            }

            return null;
        }
    }
}
