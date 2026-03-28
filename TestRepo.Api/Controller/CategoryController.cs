using Microsoft.AspNetCore.Mvc;
using TestRepo.Repository;
using TestRepo.Repository.Enity;
using TestRepo.Service.Category;
using IService = TestRepo.Service.Category.IService;

namespace TestRepo.Api.Controller;
 [ApiController]
[Route("[controller]")]
 public class CategoryController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IService _categoryService;
    public CategoryController(AppDbContext dbContext, IService categoryService)
    {
        _dbContext = dbContext;
        _categoryService = categoryService;
    }

    [HttpPost("")]
    public IActionResult CreateCategory(Request.CreateCategoryRequest request)
    {
        var category = new Category()
        {
            ParentId = request.ParentId,
            Name = request.Name
        };
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
        Console.WriteLine(request);
        return Ok("Get all categories");
    }

    [HttpGet("")]
    public async Task<IActionResult> GetCategories()
    {
        var listResult = await _categoryService .GetCategories();
        return Ok(listResult);
    }
    [HttpGet("{parentId}/childrens")]
    public async Task<IActionResult> GetCategoriesById(Guid parentId)
    {
        var listResult = await _categoryService.GetCategoryById(parentId);
        return Ok(listResult);
    }
}