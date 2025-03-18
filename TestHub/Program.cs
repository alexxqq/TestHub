using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using TestHub.BLL.Interfaces;
using TestHub.BLL.Services;
using TestHub.DAL;
using TestHub.DAL.Interfaces;
using TestHub.DAL.Repositories;
using DotNetEnv;


DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var dbSettings = configuration.GetSection("DatabaseSettings");
string connectionString = $@"
    Server={Environment.GetEnvironmentVariable("DB_HOST") ?? dbSettings["Host"]};
    Port={Environment.GetEnvironmentVariable("DB_PORT") ?? dbSettings["Port"]};
    Database={Environment.GetEnvironmentVariable("DB_NAME") ?? dbSettings["Database"]};
    UserId={Environment.GetEnvironmentVariable("DB_USER") ?? dbSettings["Username"]};
    Password={Environment.GetEnvironmentVariable("DB_PASS") ?? dbSettings["Password"]}
";

builder.Host.UseSerilog((context, config) => config
    .ReadFrom.Configuration(context.Configuration));

builder.Services.AddDbContext<TestingSystemContext>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddScoped<ISupervisorRepository, SupervisorRepository>();

builder.Services.AddScoped<ISupervisorService, SupervisorService>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

await app.RunAsync();