using FluentMigrator.Runner;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Dal;
using WorkplaceBooking.Dal.DatabaseContexts;
using WorkplaceBooking.Interfaces;
using WorkplaceBooking.Middleware;
using WorkplaceBooking.Migrations;
using WorkplaceBooking.Services;
using WorkplaceBooking.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// TODO: analize services lifetime and change
{
    builder.Services.AddLocalization(options => options.ResourcesPath = @"Resources\Localization");
    builder.Services.Configure<RequestLocalizationOptions>(options => {
        List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("ru-RU")
    };
        options.DefaultRequestCulture = new RequestCulture("ru-RU");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });
    builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options => {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(DataAnnotationSharedResource));
    });

    builder.Services.Configure<JwtAppSettings>(builder.Configuration.GetSection("JwtAppSettings"));

    builder.Services.AddScoped<IDatabaseContext, SqliteDatabaseContext>();

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

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IBookingService, BookingService>();
        builder.Services.AddScoped<IRoomManagementService, RoomManagementService>();
    }
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

// middleware
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
