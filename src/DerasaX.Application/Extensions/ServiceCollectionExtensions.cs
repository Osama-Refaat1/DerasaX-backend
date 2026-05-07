using DerasaX.Application.Services.Abstractions.Account;
using DerasaX.Application.Services.Abstractions.Grade;
using DerasaX.Application.Services.Abstractions.Lesson;
using DerasaX.Application.Services.Abstractions.LessonMaterial;
using DerasaX.Application.Services.Abstractions.Quiz;
using DerasaX.Application.Services.Abstractions.Subject;
using DerasaX.Application.Services.Abstractions.Unit;
using DerasaX.Application.Services.Account;
using DerasaX.Application.Services.Grades;
using DerasaX.Application.Services.Image.FileServices;
using DerasaX.Application.Services.LessonMaterials;
using DerasaX.Application.Services.Lessons;
using DerasaX.Application.Services.Quizzes;
using DerasaX.Application.Services.Subjects;
using DerasaX.Application.Services.Subjects.Mapping;
using DerasaX.Application.Services.Units;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterApplicationServices(configuration);
            services.AddJwtAuthentication(configuration);

            
            services.AddHttpContextAccessor();

            services.AddAutoMapperServices();
            
            
            services.AddScoped<SubjectPictureUrlResolver>();

            // Register FluentValidation
            return services;
        }
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<ISubjectServices, SubjectServices>();
            services.AddScoped<IUnitServices, UnitServices>();
            services.AddScoped<ILessonServices, LessonServices>();
            services.AddScoped<IGradeServices, GradeServices>();
            services.AddScoped<ILessonMaterialServicess, LessonMaterialServices>();
            services.AddScoped<IQuizServices, QuizServices>();
            services.AddScoped<IFileService, FileService>();
            return services;
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
        .AddJwtBearer(options =>
        {
            var secretKey = configuration["SecretKey"];

            if (string.IsNullOrEmpty(secretKey))
                throw new Exception("JWT secret key is missing in configuration!");

            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var securityKey = new SymmetricSecurityKey(keyBytes);

            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,

                NameClaimType = ClaimTypes.NameIdentifier,
                RoleClaimType = ClaimTypes.Role,

                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                // SignalR sends the token as a query parameter for WebSocket connections
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];
                    var path = context.HttpContext.Request.Path;

                    if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                        context.Token = accessToken;

                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    var tenantId = context.Principal?.FindFirst("tenantId")?.Value;

                    if (string.IsNullOrEmpty(tenantId))
                    {
                        context.Fail("TenantId is missing in token");
                    }
                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("JWT");

                    logger.LogError(context.Exception, "Authentication failed");

                    return Task.CompletedTask;
                }
            };
        });
            return services;
        }
        private static void AddAutoMapperServices(this IServiceCollection services)
        {
            var applicationsAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(applicationsAssembly);
        }

    }
}
