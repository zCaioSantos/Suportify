using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Suportify.Common.CrossCutting;
using Suportify.Domain.Interfaces.Repositories.Autenticacao;
using Suportify.Infra.Data.EFCore.Context;
using Suportify.Infra.Data.EFCore.Repositories.Autenticacao;
using Suportify.Service.Domain.Autenticacao;
using System.Globalization;
using AspNetCore.Scalar;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
IdentityModelEventSource.ShowPII = true;


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
});


builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 10485760;
});


var origins = builder.Configuration.GetSection("Origins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(origins)
            .WithExposedHeaders("Content-Disposition")
            .AllowCredentials();
    });
});


// Configura��es do Projeto
ProjectConfig.ConnectionString = builder.Configuration.GetConnectionString("Default");

var jwtSection = builder.Configuration.GetSection("Jwt");
ProjectConfig.AppSecret = jwtSection.GetValue<string>("AppSecret");


// Configura��o JWT
builder.Services.AddAuthentication().AddJwtBearer();


builder.Services.AddDbContext<EFContext>(options =>
{
    options.UseSqlServer(ProjectConfig.ConnectionString);
    options.EnableSensitiveDataLogging();
});


//builder.Services.RegisterMaps();


#region Services - Bindings
builder.Services.AddScoped<UsuarioService>();
#endregion


#region Repositories - Bindings
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
#endregion

// Swagger / OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Suportify API",
        Version = "v1"
    });

    // Autorização via JWT no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT no formato: Bearer {seu_token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

// Configure the HTTP request pipeline.

app.UseCors("DefaultCorsPolicy");

// Autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();
app.MapScalarApiReference();
app.UseScalar(options =>
{
    options.UseTheme(Theme.Default);
    options.RoutePrefix = "api-docs";
});

app.MapControllers();

app.Run();
