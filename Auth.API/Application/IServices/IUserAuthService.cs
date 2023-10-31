using Auth.API.Application.ViewModels;
using System.ComponentModel;

namespace Auth.API.Application.IServices
{
    public interface IUserAuthService
    {
        /// <summary>
        /// Registration can be done via Google or custom username/password
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, dynamic? DataObject,string[]? Errors, string Message)> Register(RegisterVM newUser);

        /// <summary>
        /// Login can be done via Google or custom username/password
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, dynamic? DataObject, string[]? Errors, string Message)> Login(LoginVM userObj);

        Task<(bool IsSuccess, dynamic? DataObject, string[]? Errors, string Message)> AddRoles(string[] roleNames);
    }
}


