using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoWeb;
using TodoWeb.IServices;
using TodoWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TodoMiniApiService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000");
});

builder.Services.AddScoped<ITodoService>(sp => new TodoService(sp.GetRequiredService<IHttpClientFactory>(), sp.GetRequiredService<ILogger<TodoService>>()));

await builder.Build().RunAsync();
