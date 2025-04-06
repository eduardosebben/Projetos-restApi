using Microsoft.Extensions.Configuration;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Repositories;
using Relatorios.Infraestrutura.Repositories;
using Relatorios.Infraestrutura.Repositories.Account;
using Relatorios.Infraestrutura.Repositories.EmpresaPadrao;
using Relatorios.Infraestrutura.Repositories.Fiscal;
using System;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddTransient<IErpRepositorioGenerico, ErpEntityFrameworkRepository>()
            .AddTransient<IRepositorioFiscal, RelatorioFiscalRepositorio>()
            .AddTransient<IRepositorioAccount, RepositorioAccountCached>()
            .AddTransient<IRepositorioEmpresasPadrao, RepositorioEmpresasPadraoEf>()
            .AddTransient<RepositorioAccount>()
            ;

        return services;
    }


    //        var connectionString = configuration.GetConnectionString("DefaultConnection");

    //        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

    //        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
    //        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

    //        services.AddDbContext<ApplicationDbContext>((sp, options) =>
    //        {
    //            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());


    //        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

    //        services.AddScoped<ApplicationDbContextInitialiser>();

    //#if (UseApiOnly)
    //        services.AddAuthentication()
    //            .AddBearerToken(IdentityConstants.BearerScheme);

    //        services.AddAuthorizationBuilder();

    //        services
    //            .AddIdentityCore<ApplicationUser>()
    //            .AddRoles<IdentityRole>()
    //            .AddEntityFrameworkStores<ApplicationDbContext>()
    //            .AddApiEndpoints();
    //#else
    //        services
    //            .AddDefaultIdentity<ApplicationUser>()
    //            .AddRoles<IdentityRole>()
    //            .AddEntityFrameworkStores<ApplicationDbContext>();
    //#endif

    //        services.AddSingleton(TimeProvider.System);
    //        services.AddTransient<IIdentityService, IdentityService>();

    //        services.AddAuthorization(options =>
    //            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));


}