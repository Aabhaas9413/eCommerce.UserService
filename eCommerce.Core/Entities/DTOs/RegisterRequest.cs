namespace eCommerce.Core.Entities.DTOs;

public record RegisterRequest(string? Email, string? Password, string? PersonName, GenderOptions Gender);


