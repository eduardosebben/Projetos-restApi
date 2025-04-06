using RelatoriosApi.API.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RelatoriosApi.Setup;
using Relatorios.Infraestrutura.Repositories.Context;
using Relatorios.Aplication.Common.Settings;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using RelatoriosApi.Authentication;
using Relatorios.Aplication.Common.Implementacoes;
using Relatorios.Dominio.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            .AddSingleton<IMemoryCache, MemoryCache>()
            .AddTransient<CustomJwtSecurityTokenHandler>();

        services.AddSingleton<ISecurityTokenValidator>(provider => {
            var criptografiaProvider = provider.GetRequiredService<ICriptografiaProvider>();
            var repositorioAccount = provider.GetRequiredService<IRepositorioAccount>();
            return new CustomJwtSecurityTokenHandler(criptografiaProvider, repositorioAccount);
        });


        

        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.SwaggerSecurityConfig();

        services.AddDbContext<ErpDatabaseConextInfraestrutura>();

        services.Configure<AutenticacaoConfiguration>(configuration.GetSection(AutenticacaoConfiguration.Section));
        services.Configure<AutenticacaoSettings>(configuration.GetSection(AutenticacaoSettings.Section));

        services.AddHealthChecks();


        var config = configuration;

        var autenticacaoSettings = config.GetSection(AutenticacaoSettings.Section).Get<AutenticacaoSettings>();
        
        if (autenticacaoSettings!.UtilizaAutenticacaoAccount)
        {
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    
                };
                options.SecurityTokenValidators.Clear();
                var securityTokenValidator = services.BuildServiceProvider().GetRequiredService<ISecurityTokenValidator>();
                options.SecurityTokenValidators.Add(securityTokenValidator);                
            });
        }
        else
        {
            services.AddAuthentication()
                .AddScheme<AuthenticationSchemeOptions, BearerAuthenticationHandler>(BearerAuthenticationDefaults.AuthenticationScheme, null);
        }

        

        return services;
    }

}