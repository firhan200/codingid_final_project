using WebApi.Repositories.Users;
using WebApi.Services.Users;

namespace WebApi;

public static class DependencyInjections {
    public static IServiceCollection RegisterRepositories(this IServiceCollection services){
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }

     public static IServiceCollection RegisterServices(this IServiceCollection services){
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}