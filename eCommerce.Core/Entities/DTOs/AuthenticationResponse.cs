namespace eCommerce.Core.Entities.DTOs;

public record AuthenticationResponse(Guid UserID, string? Email, string? PersonName, string? Gender, string? Token, bool Success)
{
    public static AuthenticationResponse From(ApplicationUser user, string token, bool success)
    {
        if (user is null) throw new ArgumentNullException(nameof(user));
        return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, token, success);
    }
}

