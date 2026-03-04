using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MottuDesafio.Application.Interfaces;
using MottuDesafio.Application.Services;
using MottuDesafio.Domain.Entities;
using MottuDesafio.InfraData.Authentication;
using MottuDesafio.InfraIoc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Desafio Back End .Net",
        Description = "API para gerenciamento de locação de motos",
        Contact = new OpenApiContact { Name = "Welinton Gomes", Email = "batistawelinton54@gmail.com" }
    });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Digite 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }},
            new string[] {}
        }
    });
});

//Jwt
var key = new SymmetricSecurityKey(
    System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)
);

var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = key
    };
});



builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

// Injeção infra
builder.Services.AddInfrastructure(builder.Configuration);

// Serviços
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILeaseService, LeaseService>();
builder.Services.AddScoped<IDeliveryMenService, DeliveryMenService>();
builder.Services.AddScoped<IMotorcyclerService, MotorcycleService>();
builder.Services.AddScoped<PasswordHasher<User>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
Console.WriteLine("Assembly da API: " + typeof(Program).Assembly.FullName);

app.Run();