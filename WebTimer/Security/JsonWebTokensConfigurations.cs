using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace WebTimer.Security
{

    public static class JsonWebTokensConfigurations
    {
        public static IServiceCollection ProvideJsonWebTokensConfigurations(this IServiceCollection services)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
                {
                    config.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Issuer",
                        ValidAudience = "audience",
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            @"hellowordthisismysecretkeyyoushouldnotreadititisasecret"
                        )),
                        NameClaimType = "jti"                        
                    };
              });
            return services;
        }
    }
}
