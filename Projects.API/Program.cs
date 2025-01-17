using Microsoft.EntityFrameworkCore;
using Projects.Application.Commands.CreateProject;
using Projects.Application.Commands.CreateUser;
using Projects.Domain.Repositories;
using Projects.Infrastructure.Persistence;
using Projects.Infrastructure.Persistence.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("ProjectCs");

builder.Services.AddDbContext<ProjetoDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly); });

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ProjetoDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
