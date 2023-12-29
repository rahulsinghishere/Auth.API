using Auth.API.Application.IServices;
using Auth.API.Application.ViewModels;
using Auth.API.Core.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Auth.API.Application.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly UserManager<ApplicationUser> _usrmgr;
        private readonly RoleManager<ApplicationUserRole> _rolemgr;
        private readonly ILogger<UserAuthService> _logger;
        private readonly IConfiguration _configuration;

        public UserAuthService(UserManager<ApplicationUser> usrMgr, RoleManager<ApplicationUserRole> roleMgr, ILogger<UserAuthService> logger, IConfiguration configuration)
        {
            this._usrmgr = usrMgr;
            this._rolemgr = roleMgr;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<(bool IsSuccess, dynamic? DataObject, string[]? Errors, string Message)> AddRoles(string[] roleNames)
        {
            if(roleNames == null || roleNames.Length == 0)
            {
                return (false, null, new string[] { "roleNames is Empty" }, "roleNames is Empty");
            }
            for(int i = 0;i < roleNames.Length; i++) 
            {
                ApplicationUserRole r = new ApplicationUserRole()
                {
                    Name = roleNames[i],
                    NormalizedName = roleNames[i].ToUpper()
                };

                if (this._rolemgr.Roles.Any(role => role.Name == roleNames[i]))
                {
                    await this._rolemgr.UpdateNormalizedRoleNameAsync(r);
                    continue;
                }
                await this._rolemgr.CreateAsync(r);
            }

            return (true, null, null, "Roles Created");
            
        }

        public async Task<(bool IsSuccess, dynamic? DataObject, string[]? Errors, string Message)> Login(LoginVM userObj)
        {
            var userexists = await _usrmgr.FindByEmailAsync(userObj.EmailID);
            if(userexists != null && await _usrmgr.CheckPasswordAsync(userexists,userObj.UserPassword)) 
            {
                var usrroles = await _usrmgr.GetRolesAsync(userexists);
                //Token
                var tokendetails = GenerateJWTAuthToken(userexists,usrroles);

                AuthenticatedUser authenticateduser = new AuthenticatedUser 
                { 
                    AuthToken=tokendetails,
                    EmailID=userObj.EmailID,
                    FirstName = userexists.FirstName, 
                    LastName = userexists.LastName
                };

                return (true, authenticateduser, null, "User Logged In");
            }
            return (false, null, null, "UnAuthorized User");
        }

        public async Task<(bool IsSuccess, dynamic? DataObject, string[]? Errors, string Message)> Register(RegisterVM newUser)
        {
            var roleobj = await this._rolemgr.FindByNameAsync(newUser.RoleName);
            if (roleobj == null)
            {
                return (false, null, null, "Please Enter Valid Role");
            }

            var result = await this._usrmgr.CreateAsync(new ApplicationUser()
            {
                Email = newUser.EmailID,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PhoneNumber = newUser.PhoneNumber,
                UserName = newUser.UserName,
                UserRegistrationSource = newUser.RegistrationSource.ToString()
            },newUser.UserPassword);

            if(result.Succeeded) 
            {
                var newuser = await this._usrmgr.FindByEmailAsync(newUser.EmailID);
                //Assign Role
                var roleassigned = await this._usrmgr.AddToRoleAsync(newuser, roleobj.Name);

                if(roleassigned.Succeeded) 
                {
                    return (true, null, null, "User Created and Role Assigned Successfully");
                }

            }

            return (false, null, result.Errors.Select(i=>i.Description).ToArray(), "Error Occurred");
        }

        private AuthTokenVM GenerateJWTAuthToken(ApplicationUser user, IList<string> userRoles)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException($"{nameof(user)} cannot be null");
                }

                //List Claims for Token
                List<Claim> claims = new List<Claim>() 
                {
                    new Claim(ClaimTypes.Name,user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(ClaimTypes.Surname,user.LastName),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email!),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                foreach (var usrrole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, usrrole));
                }

                string? secretkey = this._configuration["JWT:SecretKey"];
                string? issuer = this._configuration["JWT:Issuer"];
                string? audience = this._configuration["JWT:Audience"];

                if (string.IsNullOrWhiteSpace(secretkey))
                {
                    throw new ArgumentNullException("Secret Key for Token is not defined");
                }
                //Get Secret Key for Token
                SymmetricSecurityKey authsigninkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretkey));

                JwtSecurityToken token = new JwtSecurityToken(issuer, audience, claims, DateTime.Now, DateTime.Now.AddMinutes(1), new SigningCredentials(authsigninkey,SecurityAlgorithms.HmacSha256));

                string jwttoken = new JwtSecurityTokenHandler().WriteToken(token);

                AuthTokenVM authtokenvm = new AuthTokenVM()
                {
                    Token = jwttoken,
                    ExpirationAt = token.ValidTo
                };

                return authtokenvm;
            }
            catch (Exception ex) 
            {
                this._logger.LogError(ex.Message, ex);
                return null;
            }
            
        }
    }
}



