using TestRepo.Repository.Abtraction;

namespace TestRepo.Repository.Enity;

public class Category: BaseEntity<Guid>, IAuditablEntity
{
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public required string Name { get; set; }
    public Guid Id { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}