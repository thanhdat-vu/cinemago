using CinemaGo.Application.Abstractions;
using CinemaGo.Infrastructure;
using CinemaGo.Infrastructure.Auth;
using CinemaGo.Infrastructure.Persistence;
using CinemaGo.WebServer;
using CinemaGo.WebServer.ApiEndpoints;
using CinemaGo.WebServer.CronJobs;
using CinemaGo.WebServer.Hubs;
using CinemaGo.WebServer.Middlewares;
using JasperFx;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.AddWolverine();

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthInfrastructure(builder.Configuration);
builder.Services.AddSingleton<ITicketRealtimePublisher, SignalRTicketRealtimePublisher>();
builder.Services.AddHostedService<TicketLockRecoveryHostedService>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapGet("/apis", () => Results.Redirect("scalar/v1"));

app.MapAuthEndpoints();
app.MapBookingEndpoints();
app.MapShowTimeEndpoints();
app.MapCinemaEndpoints();
app.MapMovieEndpoints();
app.MapScreenEndpoints();
app.MapHub<TicketStatusHub>("/hubs/tickets").AllowAnonymous(); 

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using var scope = app.Services.CreateScope();
try
{
    // Migrate Orders
    var orderContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await orderContext.Database.MigrateAsync();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    await IdentityDataSeeder.SeedAsync(roleManager, loggerFactory.CreateLogger("IdentitySeed"));

    // Seed data
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Error during database migration or seeding: {ex.Message}");
    throw;
}

return await app.RunJasperFxCommands(args);

/// <summary>
/// Exposes the implicit program class to Alba / WebApplicationFactory integration tests.
/// </summary>
public partial class Program;