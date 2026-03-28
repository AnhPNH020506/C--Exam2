using Microsoft.AspNetCore.Mvc;
using TestRepo.Repository;
using TestRepo.Repository.Enity;
using TestRepo.Service.Seller;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class SellerController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    public SellerController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("")]
    public IActionResult CreateSeller([FromBody] Request.CreateSellerRequest request)
    {
        var seller = new Seller()
        {
            TaxCode = request.TaxCode,
            CompanyAddress = request.CompanyAddress,
            CompanyName = request.CompanyName,

        };
        _dbContext.Add(seller);
        _dbContext.SaveChanges();
        return Ok(seller);
    }
}