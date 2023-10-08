using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Scheme = "Bearer",
        Type = SecuritySchemeType.Http,
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//Authentication
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddJwtBearer(options => {
    var jwtSecretObj = builder.Configuration.GetSection("JWT:Key");
    string jwtSecret = jwtSecretObj.Value ?? "";
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret))
    };
});

//register dependencies
builder.Services.RegisterRepositories().RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.DisplayOperationId();
    });
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
