using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;

namespace TestRepo.Service.Category;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Response.GetCategoryResponse>> GetCategories()
    {
        var query = _dbContext.Categories.OrderBy(x => x.Name);
        var selectQuery = query.Select(x => new Response.GetCategoryResponse()
        {

            Id = x.Id,
            Name = x.Name,
            ParentId = x.ParentId
        });
        var result =  await selectQuery.ToListAsync();
        return result;

    }

    public async Task<List<Response.GetCategoryResponse>> GetCategoryById(Guid id)
    {
        var query = _dbContext.Categories.Where(x => x.ParentId == id);
        query = query.OrderBy(x => x.Name);
        var selectQuery = query.Select(x => new Response.GetCategoryResponse()
        {

            Id = x.Id,
            Name = x.Name,
            ParentId = x.ParentId
        });
        var result =  await selectQuery.ToListAsync();
        return result;
    }
}