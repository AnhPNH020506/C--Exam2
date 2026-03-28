namespace TestRepo.Repository.Abtraction;

public interface IAuditablEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}