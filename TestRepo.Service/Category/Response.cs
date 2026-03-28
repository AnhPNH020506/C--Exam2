namespace TestRepo.Service.Category;

public class Response
{
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}