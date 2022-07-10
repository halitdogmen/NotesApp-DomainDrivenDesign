using Microsoft.OpenApi.Models;
using System.Reflection;

namespace NotesApp.API.Extensions
{
    public static class SwashbuckleRegistirationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}NotesApp.API.xml");
                c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}NotesApp.Application.Contracts.xml");
                c.UseAllOfToExtendReferenceSchemas();
                c.UseAllOfForInheritance();
                c.UseOneOfForPolymorphism();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotesApp", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
