using TodoMiniAPI.Endpoints;
using TodoMiniAPI.Extensions;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAppServices();

//CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("TodoWeb",
        builder => builder.WithOrigins("http://localhost:5069")
                       .AllowAnyHeader()
                       .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("TodoWeb"); 

// Configure pipeline - use method
TodoEndpoints.Map(app);

app.Run();
