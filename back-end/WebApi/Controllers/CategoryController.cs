using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Constants;
using WebApi.Dto;
using WebApi.Services.Categories;

namespace WebApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CategoryController : ControllerBase {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet(Name = "Get all course categories")]
    public IResult GetAllCategory(){
        var res = _categoryService.GetAll();

        return Results.Ok(res);
    }

    [Authorize(Roles = "admin")]
    [HttpPost(Name = "Create new cource category")]
    public IResult Create([FromBody] CreateCategoryRequest createCategoryRequest){
        //upload image here
        //....

        var res = _categoryService.Create(createCategoryRequest.Name, "", createCategoryRequest.Description);

        return Results.Ok();
    }
}