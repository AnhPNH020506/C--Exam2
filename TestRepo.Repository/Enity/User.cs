using TestRepo.Repository.Abtraction;

namespace TestRepo.Repository.Enity;

public class User : BaseEntity<Guid>, IAuditablEntity
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Role { get; set; }
    
    public Seller Seller { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}