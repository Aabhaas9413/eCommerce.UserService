namespace eCommerce.Core.Entities.DTOs;

public record AuthenticationResponse(Guid UserID, string? Email, string? PersonName, string? Gender, string? Token, bool Success);

