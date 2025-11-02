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

        public async Task<AuthenticationResponse?> Login(LoginRequest? loginRequest)
        {
            if (loginRequest is null)
            {
                return null;
            }

            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user is null)
            {
                return null;
            }

            return AuthenticationResponse.From(user, " ", true);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest? registerRequest)
        {
            if (registerRequest is null)
            {
                return null;
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender = registerRequest.Gender.ToString(),
            };

            ApplicationUser? user = await _userRepository.AddUser(newUser);
            if (user is null)
            {
                return null;
            }

            return AuthenticationResponse.From(user, string.Empty, true);
        }
    }
}