using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Context;
using Todo.Domain.Infra.Repository;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

//Injection Dependecy
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.Authority = "https://securetoken.google.com/todos-e41f9";
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/todos-e41f9",
            ValidateAudience = true,
            ValidAudience = "todos-e41f9",
            ValidateLifetime = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
