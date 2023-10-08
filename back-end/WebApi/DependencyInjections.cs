using WebApi.Repositories.Categories;
using WebApi.Repositories.Users;
using WebApi.Services.Categories;
using WebApi.Services.Image;
using WebApi.Services.Password;
using WebApi.Services.Token;
using WebApi.Services.Users;

namespace WebApi;

public static class DependencyInjections {
    public static IServiceCollection RegisterRepositories(this IServiceCollection services){
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        return services;
    }

     public static IServiceCollection RegisterServices(this IServiceCollection services){
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IImageService, ImageService>();
        
        return services;
    }
}