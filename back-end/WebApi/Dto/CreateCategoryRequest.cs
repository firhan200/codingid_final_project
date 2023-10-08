namespace WebApi.Dto;

public record CreateCategoryRequest {
    public string Name {get;set;} = string.Empty;
    public string Image {get;set;} = string.Empty;
    public string Description {get;set;} = string.Empty;
}