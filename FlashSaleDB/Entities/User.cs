namespace FlashSaleDB.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = String.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public string? Role { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}