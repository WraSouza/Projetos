using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Projects.Application.Commands.CreateActivity;
using Projects.Application.Commands.CreateProject;
using Projects.Application.Commands.CreateUser;
using Projects.Domain.Repositories;
using Projects.Infrastructure.Auth;
using Projects.Infrastructure.Notifications;
using Projects.Infrastructure.Persistence;
using Projects.Infrastructure.Persistence.Repositories;
using SendGrid.Extensions.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ProjectCs");

builder.Services.AddDbContext<ProjetoDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateActivityCommand).Assembly); });

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddSingleton<IAuthService, AuthService>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSendGrid(o =>
{
    o.ApiKey = builder.Configuration.GetValue<string>("SendGrid:ApiKey");
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();   // Generate Swagger JSON
    app.UseSwaggerUI(); // Serve Swagger UI for interactive API documentation
    //app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
