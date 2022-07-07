using Microsoft.AspNetCore.Authentication.JwtBearer;
using SeedWork.Application.Utils.JWT.Concrete;
using Microsoft.IdentityModel.Tokens;
using SeedWork.Application.Utils.Encryption;

namespace NotesApp.API.Extensions
{
    public static class AuthenticationRegistrationExtension
    {
        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                {
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidateAudience = true,
                                        ValidateLifetime = true,
                                        ValidIssuer = tokenOptions.Issuer,
                                        ValidAudience = tokenOptions.Audience,
                                        ValidateIssuerSigningKey = true,
                                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                                    };
                                });
        }
    }
}
