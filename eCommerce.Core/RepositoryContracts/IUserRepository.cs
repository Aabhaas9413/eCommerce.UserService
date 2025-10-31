using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser> AddUserAsync(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
