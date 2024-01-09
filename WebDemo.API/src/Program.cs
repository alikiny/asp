using System.Security.Claims;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebDemo.API.src.Authorization;
using WebDemo.API.src.Database;
using WebDemo.API.src.Middleware;
using WebDemo.API.src.Repository;
using WebDemo.API.src.Service;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.Service;
using WebDemo.Business.src.Shared;
using WebDemo.Core.src.Abstraction;
using Npgsql;
using WebDemo.Core.src.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Bearer token authentication",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = "Bearer"
        }
        );

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    }
);

// add controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// add database service
var dataSourceBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
dataSourceBuilder.MapEnum<Role>();
var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options
    .UseNpgsql(dataSource);
}
);

// add automapper service
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

// add DI services
builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IAddressService, AddressService>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IProductColorService, ProductColorService>()
    .AddScoped<IProductSizeService, ProductSizeService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IOrderDetailService, OrderDetailService>()
    .AddScoped<IImageService, ImageService>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<IAvartarService, AvatarService>()
    .AddScoped<IProductLineService, ProductLineService>()
    .AddScoped<ICategoryService, CategoryService>()
;

builder.Services
    .AddScoped<IUserRepo, UserRepo>()
    .AddScoped<IImageRepo, ImageRepo>()
    .AddScoped<IProductRepo, ProductRepo>()
    .AddScoped<IProductColorRepo, ProductColorRepo>()
    .AddScoped<IProductSizeRepo, ProductSizeRepo>()
    .AddScoped<IOrderRepo, OrderRepo>()
    .AddScoped<IOrderDetailRepo, OrderDetailRepo>()
    .AddScoped<IAddressRepo, AddressRepo>()
    .AddScoped<IAvatarRepo, AvartarRepo>()
    .AddScoped<IProductLineRepo, ProductLineRepo>()
    .AddScoped<ICategoryRepo, CategoryRepo>();

// add DI custom authorization services
builder.Services.AddSingleton<IAuthorizationHandler, CheckAddressHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, AdminOrOwnerHandler>();

// add DI custom middleware
builder.Services.AddTransient<ExceptionHandlerMiddleWare>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    }
);

builder.Services.AddAuthorization(policy =>
{
    policy.AddPolicy("SuperAdmin", policy => policy.RequireClaim(ClaimTypes.Email, "alia@mail.com", "alia2@mail.com")); //claim-based
    policy.AddPolicy("MaxLength", policy => policy.AddRequirements(new CheckAddressRequirement(10)));
    policy.AddPolicy("AdminOrOwner", policy => policy.AddRequirements(new AdminOrOwnerRequirement()));
});

// build app
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty; // "/swagger/index.html"
});

// Add middlewares
app.UseCors(options => options.AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// execute app
app.Run();

