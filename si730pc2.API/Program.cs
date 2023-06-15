using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using si730pc2.API.Mapper;
using si730pc2u202110085.Domain;
using si730pc2u202110085.Domain.Infrastructure;
using si730pc2u202110085.Infrastructure;
using si730pc2u202110085.Infrastructure.Context;
using si730pc2u202110085.Infrastructure.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IPlanDomain, PlanDomain>();
builder.Services.AddScoped<IPlanInfrastructure, PlanInfrastructure>();

// MySQL Connection
var connectionString = builder.Configuration.GetConnectionString("WebApplicationConnection");

builder.Services.AddDbContext<ProjectContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

// Mapper
builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel)
);

// Port 7070


var app = builder.Build();

// Create database
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<ProjectContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();