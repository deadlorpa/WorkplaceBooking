using FluentMigrator.Runner;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Dal;
using WorkplaceBooking.Dal.Repositories;
using WorkplaceBooking.Interfaces;
using WorkplaceBooking.Middleware;
using WorkplaceBooking.Migrations;
using WorkplaceBooking.Services;
using WorkplaceBooking.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.Configure<JwtAppSettings>(builder.Configuration.GetSection("JwtAppSettings"));
    builder.Services.AddSingleton<DatabaseContext>();
    builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
    .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSQLite()
                               .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DatabaseConnectionString"))
                               .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()
        );
    builder.Services.AddCors();
    builder.Services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddScoped<IJwtUtils, JwtUtils>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Write your token",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
           {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
           },
             new string[] {}
        }
    });
});

var app = builder.Build();

app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
