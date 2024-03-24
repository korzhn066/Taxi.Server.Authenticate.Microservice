using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Taxi.Server.Authenticate.Microservice.Api.Configuration;
using Taxi.Server.Authenticate.Microservice.Application;
using Taxi.Server.Authenticate.Microservice.Application.Services;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Repositories;
using Taxi.Server.Authenticate.Microservice.Domain.Interfaces.Services;
using Taxi.Server.Authenticate.Microservice.Infrastructure;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Data;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityConfiguration();
builder.Services.AddAuthenticateConfiguration(builder);

builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<ICandidateDriverRepository, CandidateDriverRepository>();

builder.Services.AddScoped<IApplicationAuthenticateService, ApplicationAuthenticateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(x => x
        .WithOrigins("http://localhost:3000")
        .WithOrigins("http://localhost:3001")
        .WithOrigins("http://localhost:3002")
        .WithOrigins("http://localhost:7255")
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies[".AspNetCore.Application.Id"];
    if (!string.IsNullOrEmpty(token))
        context.Request.Headers.Add("Authorization", "Bearer " + token);

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
