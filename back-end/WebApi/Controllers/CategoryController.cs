using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Constants;

namespace WebApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CategoryController : ControllerBase {
    [HttpGet(Name = "Get all course categories")]
    public IResult GetAllCategory(){
        return Results.Ok();
    }

    [Authorize(Roles = "admin")]
    [HttpPost(Name = "Create new cource category")]
    public IResult Create(){
        return Results.Ok();
    }
}