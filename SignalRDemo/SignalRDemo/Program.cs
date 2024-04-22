using SignalRDemo.Client.Pages;
using SignalRDemo.Components;
using SignalRDemo.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSignalR();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapHub<WorkflowHub>("/workflowhub");

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SignalRDemo.Client._Imports).Assembly);

app.Run();
