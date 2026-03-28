namespace TestRepo.Service.Category;

public class Request
{
    public class CreateCategoryRequest
    {
        public Guid? ParentId { get; set; }
        public required string Name { get; set; }
    }
}