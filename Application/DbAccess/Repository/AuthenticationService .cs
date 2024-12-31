using Application.Common.Interfaces;
using Application.DbAccess.Interfaces;
using Domain.Common;
using Domain.Master;
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
                        new("Name", user.FirstName+" "+user.LastName),
                        new("Email", user.EmailId),
                        new("Role", user.RoleId.ToString()),
                        new("NameIdentifier", user.Id.ToString()),
                        new("MobileNo", user.MobileNo),
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = GetToken(authClaims);

                return new ApiResponse() { Data =new JwtSecurityTokenHandler().WriteToken(token),Status="Success",StatusCode=(int)HttpStatusCode.OK,Message="User validated successfully." };
            }
            catch (Exception ex)
            {
                throw;
                //return new ApiResponse() {  Status = "Failed", StatusCode = (int)HttpStatusCode.BadRequest, Message =  ex.Message};
            }

        }

        public async Task<ApiResponse> RegisterUser(RegisterRequest register)
        {
            try
            {
                var user = new UserMaster()
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    EmailId = register.EmailId,
                    MobileNo = register.MobileNo,
                    Password = register.Password,
                    Address = register.Address,
                    City = register.City,
                    StateId = register.StateId,
                    CountryId = register.CountryId,
                    Pincode = register.Pincode,
                    RoleId = 1,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow
                };

                _applicationDBContext.UserMasters.Add(user);
                var result = await _applicationDBContext.SaveChangesAsync();
                return new ApiResponse() { Data = result, Status = "Success", StatusCode = (int)HttpStatusCode.OK, Message = "New user registered successfully." };
            }
            catch (Exception ex)
            {
                return new ApiResponse() { Status = "Failed", StatusCode = (int)HttpStatusCode.BadRequest, Message = ex.Message };
            }
            
        }

        public async Task<ApiResponse> GetAllUser()
        {
            try
            {
                var userList = await _applicationDBContext.UserMasters.Where(x=>x.IsActive).OrderBy(x => x.Id).Select(x => new
                {
                    FirstName=x.FirstName,
                    StateCode=x.StateMaster.StateCode,
                    StateName=x.StateMaster.StateName,
                    CountryName=x.CountryMaster.CountryName,
                    LastName=x.LastName,
                    EmailId=x.EmailId,
                    MobileNo=x.MobileNo,
                    City=x.City,
                    Pincode=x.Pincode,
                    Address=x.Address,
                    RoleName=x.RoleMaster.RoleName,
                    RoleId=x.RoleId,
                    CountryId=x.CountryId,
                    StateId=x.StateId,
                    UserId=x.Id
                }).ToListAsync();
                return new ApiResponse() { StatusCode = (int)HttpStatusCode.OK,Status="Success",Data= userList,Message="All records fetched successfully"};
            }
            catch (Exception ex)
            {
                return new ApiResponse() { Status = "Failed", StatusCode = (int)HttpStatusCode.BadRequest, Message = ex.Message };
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
