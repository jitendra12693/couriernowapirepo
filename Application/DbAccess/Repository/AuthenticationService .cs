using Application.Common.Interfaces;
using Application.DbAccess.Interfaces;
using Domain.Common;
using InTimeCourier.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.DbAccess.Repository
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApplicationDBContext _applicationDBContext;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IApplicationDBContext applicationDBContext, IConfiguration configuration)
        {
            _applicationDBContext = applicationDBContext;
            _configuration = configuration;
        }
        public async Task<ApiResponse> MakeLogin(LoginRequest login)
        {
            try
            {
                var user = await _applicationDBContext.UserMasters.Where(x => (x.EmailId == login.Username && x.Password == login.Password && x.IsActive)).FirstOrDefaultAsync();


                if (user is null)
                {
                    return new ApiResponse() { Status = "Failed", StatusCode = (int)HttpStatusCode.NotFound, Message = $"Unable to authenticate user {login.Username}" };
                }

                var authClaims = new List<Claim>
                {
                        new(ClaimTypes.Name, user.FirstName+" "+user.LastName),
                        new(ClaimTypes.Email, user.EmailId),
                        new(ClaimTypes.Role, user.RoleId.ToString()),
                        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = GetToken(authClaims);

                return new ApiResponse() { Data =new JwtSecurityTokenHandler().WriteToken(token),Status="Success",StatusCode=(int)HttpStatusCode.OK,Message="User validated successfully." };
            }
            catch (Exception ex)
            {
                return new ApiResponse() {  Status = "Failed", StatusCode = (int)HttpStatusCode.BadRequest, Message =  ex.Message};
            }

        }

        private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Key:Key"],
                audience: _configuration["Key:Issuer"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
