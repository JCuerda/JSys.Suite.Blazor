using JSys.Suite.Blazor.Components;
using JSys.Suite.Blazor.Components.Authentication.Client;
using Microsoft.AspNetCore.Authentication;
using Radzen;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

builder.Services.AddRadzenComponents();
builder.Services.AddScoped<TooltipService>();

builder.Services.AddRefitClient<IAuthenticationApiClient>()
	.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7001"));

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

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(JSys.Suite.Blazor.Client._Imports).Assembly);

app.Run();