using TestRepo.Repository.Abtraction;

namespace TestRepo.Repository.Enity;

public class Product : BaseEntity<Guid>, IAuditablEntity
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public Guid SellerId { get; set; }
    public Seller Seller { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}