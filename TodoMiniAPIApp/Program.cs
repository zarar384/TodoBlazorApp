using TodoMiniAPI.Endpoints;
using TodoMiniAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DI - Add Service 
builder.Services.AddAppServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure pipeline - use method
TodoEndpoints.Map(app);

app.Run();