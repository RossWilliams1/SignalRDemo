using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient();
//To-Do move to config
builder.Services.AddHttpClient("WorkflowService", config =>
{
    config.BaseAddress = new Uri("https://localhost:7999/api/v1");
    config.Timeout = new TimeSpan(0, 0, 30);
    config.DefaultRequestHeaders.Clear();
});
//To-Do move to config
builder.Services.AddHttpClient("WorkerService", config =>
{
    config.BaseAddress = new Uri("https://localhost:7065");
    config.Timeout = new TimeSpan(0, 0, 30);
    config.DefaultRequestHeaders.Clear();
});

await builder.Build().RunAsync();
