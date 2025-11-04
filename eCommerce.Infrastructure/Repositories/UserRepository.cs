using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.DTOs;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
       user.UserID = Guid.NewGuid();
        const string query = @"INSERT INTO public.""Users"" (""UserID"", ""Email"", ""Password"", ""PersonName"", ""Gender"")
                      VALUES (@UserID, @Email, @Password, @PersonName, @Gender);";

        int rowsAffectedCount = await _dbContext.DbConnection.ExecuteAsync(query, user);
        if (rowsAffectedCount == 0)
        {
            throw new Exception("Insertion of new user failed.");
        }

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = @"SELECT * FROM public.""Users"" WHERE ""Email""=@Email AND  ""Password""=@Password";
        var parameters = new { Email = email, Password = password };
        return await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
    }
}

