using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Service.PizzaPos.Helpers;
using Application.Interface;
using Application.Main;
using Domain.Core;
using Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Transversal.Common;
using Transversal.Logging;
using Transversal.Mapping;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var appSettings = new AppSettings();
builder.Configuration.GetSection("Configurations").Bind(appSettings);

// Add services to the container.

#region Services

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Configurations"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IFactoryConnection, FactoryConnection>();

builder.Services.AddScoped<ICountryApplication, CountryApplication>();

builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();

builder.Services.AddScoped<IEmployeeApplication, EmployeeApplication>();

builder.Services.AddScoped<ILocalityApplication, LocalityApplication>();

builder.Services.AddScoped<IOrderApplication, OrderApplication>();

builder.Services.AddScoped<IProductApplication, ProductApplication>();

builder.Services.AddScoped<IProvinceApplication, ProvinceApplication>();

builder.Services.AddScoped<IUserApplication, UserApplication>();

builder.Services.AddScoped<ICountryDomain, CountryDomain>();

builder.Services.AddScoped<ICustomerDomain, CustomerDomain>();

builder.Services.AddScoped<IEmployeeDomain, EmployeeDomain>();

builder.Services.AddScoped<ILocalityDomain, LocalityDomain>();

builder.Services.AddScoped<IOrderDomain, OrderDomain>();

builder.Services.AddScoped<IProductDomain, ProductDomain>();

builder.Services.AddScoped<IProvinceDomain, ProvinceDomain>();

builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<ICountryRepository, CountryRespository>();

builder.Services.AddScoped<ICustomerRepository, CustomerRespository>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<ILocalityRepository, LocalityRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzeria POS", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = appSettings.Issuer,
            ValidAudience = appSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(appSettings.Secret ?? string.Empty)
            ),
        };
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Database Initializer

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Recreate database
        var factoryConnection = services.GetRequiredService<IFactoryConnection>();
        factoryConnection.RecreateDatabase();

        // Initialize database schema
        factoryConnection.InitializeDatabase();

        // Seed initial data
        factoryConnection.SeedData();
    }
    catch (Exception)
    {
        var logger = services.GetRequiredService<IAppLogger<Program>>();
        logger.LogError("An error occurred during database initialization.");
        throw; // Handle or rethrow as needed
    }
}

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
