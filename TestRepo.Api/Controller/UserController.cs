using Microsoft.AspNetCore.Mvc;
using TestRepo.Repository;
using TestRepo.Repository.Enity;
using TestRepo.Service.Category;
using Request = TestRepo.Service.User.Request;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    public UserController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("")]
    public IActionResult Createuser(Request.CreateUserRequest request)
    {
        var result = new User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "User",
        };
        _dbContext.Add(result);
        _dbContext.SaveChanges();
        return Ok("Add new user success");
    }
}