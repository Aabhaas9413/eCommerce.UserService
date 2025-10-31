using eCommerce.Core.Entities;
using eCommerce.Core.Entities.DTOs;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    public async Task<ApplicationUser> AddUserAsync(ApplicationUser user)
    {
       user.UserID = Guid.NewGuid();
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
      return new ApplicationUser()
      {
          UserID
          = Guid.NewGuid(),
          Email = email,
          Password = password,
          PersonName = "Test",
          Gender = GenderOptions.Male.ToString(),
      };
    }
}

