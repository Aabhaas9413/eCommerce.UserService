using eCommerce.Core.Entities;
using eCommerce.Core.Entities.DTOs;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user is null)
            {
                return null;
            }
            return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, " ", true);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest? registerRequest)
        {
            ApplicationUser newUser = new ApplicationUser()
            {
                Email = registerRequest?.Email,
                Password = registerRequest?.Password,
                PersonName = registerRequest?.PersonName,
                Gender = registerRequest.Gender.ToString(),
            };
            ApplicationUser? user = await _userRepository.AddUser(newUser);
            if (user is null)
            {
                return null;
            }
            return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "", true);


        }
    }
}