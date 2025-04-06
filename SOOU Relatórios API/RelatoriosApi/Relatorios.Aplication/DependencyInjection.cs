using Microsoft.Extensions.Configuration;
using Relatorios.Aplication.Common.Implementacoes;
using Relatorios.Aplication.DRE.Services;
using Relatorios.Aplication.EvolucaoCompras.Services;
using Relatorios.Aplication.FaturamentoContratos.Services;
using Relatorios.Aplication.Fiscal.Services;
using Relatorios.Aplication.Inventario.Services;
using Relatorios.Aplication.Vendas.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped<RelatorioLivroSaidasService>()
            .AddScoped<RelatorioApuracaoIcmsService>()
            .AddScoped<AnaliseFaturamentoContratoService>()
            .AddScoped<IRelatorioLivroFiscalService, RelatorioLivroFiscalService>()
            .AddScoped<ICriptografiaProvider, CriptografiaProvider>()
            .AddScoped<IServicoRelatorioInventario, ServicoRelatorioInventario>()
            .AddScoped<IEvolucaoCompraService, EvolucaoComprasService>()
            .AddScoped<IServicoRelatorioDRE, ServicoRelatorioDRE>()
            .AddScoped<IServicoRelatorioNFeNFCe, RelatorioNFeNFCeService>()
            .AddScoped<IGerarFaturamentoContratoService, GerarFaturamentoContratoService>();

            
        return services;
    }
}