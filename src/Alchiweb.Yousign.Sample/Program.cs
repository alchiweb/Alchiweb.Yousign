using Alchiweb.Yousign.Sample.Core.Features.Yousign;
using Alchiweb.Yousign.Sample.Features;
using Alchiweb.Yousign.Sample.Features.Yousign;
using Alchiweb.Yousign.Sample.Infrastructure.Data;
using Alchiweb.Yousign.Sample.Infrastructure.Services;
using ArcaneWebhook.Server.Api.Features.Yousign;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICryptoService, CryptoService>();
builder.Services.AddScoped<IYousignService, YousignService>();
builder.Services.AddScoped<ISignatureService, SignatureService>();

builder.Services.AddSingleton<DtoMapper>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped(typeof(IRepository<,>), typeof(EfRepositoryApp<,>));

// Mainly for deserialization for Http requests
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// For manual serialization/deserialization (with injection dependency)
builder.Services.AddSingleton(sp =>
{
    JsonSerializerOptions options = new JsonSerializerOptions()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    return options;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    app.MapOpenApi().CacheOutput("AppResponseCachePolicy");
    app.MapScalarApiReference().CacheOutput("AppResponseCachePolicy");
    app.MapGet("/", () => Results.Redirect("/scalar")).ExcludeFromDescription();
    app.MapGet("/swagger", () => Results.Redirect("/scalar")).ExcludeFromDescription();
}

app.UseHttpsRedirection();

app.MapGroup("/webhook").UseYousignWebHookEndpoints();

app.MapGroup("/api").RequireApiKeyAuthentication().UseSignatureApiEndpoints();

app.Run();
