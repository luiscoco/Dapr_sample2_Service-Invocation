using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using frontend.Data;
using Dapr.Client;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// JsonSerializer options
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDaprClient(builder =>
{
    builder.UseJsonSerializationOptions(options);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
