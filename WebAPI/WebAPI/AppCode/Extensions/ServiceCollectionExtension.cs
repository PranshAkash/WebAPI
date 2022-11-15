using Data;
using Entities.Models;
using FluentMigrator.Runner;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Services.Identity;
using System.Data;
using System.Reflection;
using WebAPI.AppCode.Helper;
using WebAPI.AppCode.Reops;

namespace WebAPI.AppCode.Extensions
{
    public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        string dbConnectionString = configuration.GetConnectionString("SqlConnection");
        GlobalDiagnosticsContext.Set("connectionString", dbConnectionString);
        IDbConnection ch = new ConnectionString { connectionString = dbConnectionString };

        //services.AddScoped<IEmailService, EmailFactory>();
        services.AddSingleton<IDbConnection>(ch);
       services.AddScoped<IUserStore<ApplicationUser>, UserStore>();
        services.AddScoped<IRoleStore<ApplicationRole>, RoleStore>();
        services.AddScoped<WebAPI.AppCode.Interfaces.ILog, LogNLog>();
        services.AddScoped<WebAPI.AppCode.Migrations.Database>();
        services.AddAutoMapper(typeof(Startup));
        services.AddHangfire(x => x.UseSqlServerStorage(dbConnectionString));
        services.AddHangfireServer();
        services.AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSqlServer2016()
            .WithGlobalConnectionString(configuration.GetConnectionString("SqlConnection"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
        JWTConfig jwtConfig = new JWTConfig();
        configuration.GetSection("JWT").Bind(jwtConfig);
        services.AddSingleton(jwtConfig);

        //services.AddSwaggerGen(option =>
        //{
        //    option.SchemaFilter<SwaggerIgnoreFilter>();
        //    option.SwaggerDoc("v1", new OpenApiInfo
        //    {
        //        Version = "v1.1"
        //    });
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ApiDoc.xml");
        //    //var filePath = Path.Combine(System.AppContext.BaseDirectory, "ApiDoc.xml");
        //    option.IncludeXmlComments(filePath);
        //    option.OperationFilter<AddRequiredHeaderParameter>();
        //    //var jwtSecurityScheme = new OpenApiSecurityScheme
        //    //{
        //    //    Scheme = "bearer",
        //    //    BearerFormat = "JWT",
        //    //    Name = "JWT Authentication",
        //    //    In = ParameterLocation.Header,
        //    //    Type = SecuritySchemeType.Http,
        //    //    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        //    //    Reference = new OpenApiReference
        //    //    {
        //    //        Id = JwtBearerDefaults.AuthenticationScheme,
        //    //        Type = ReferenceType.SecurityScheme
        //    //    }
        //    //};
        //    // option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        //    //option.AddSecurityRequirement(
        //    //    new OpenApiSecurityRequirement{
        //    //        { jwtSecurityScheme, Array.Empty<string>() }
        //    //    });
        //    option.UseAllOfToExtendReferenceSchemas();
        //});
    }
}
