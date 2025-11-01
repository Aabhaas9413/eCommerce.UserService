
using eCommerce.Core.Entities.DTOs;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    /// <summary>
    /// Method to authenticate user based on username and password
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest? loginRequest);
    /// <summary>
    /// Method to register a new user
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest? registerRequest);
}