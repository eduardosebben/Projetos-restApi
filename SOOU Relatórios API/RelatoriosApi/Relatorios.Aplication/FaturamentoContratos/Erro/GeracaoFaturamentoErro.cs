using Relatorios.Aplication.Common.Estruturas;

namespace Relatorios.Aplication.EvolucaoCompras.Erro
{
    internal static class GeracaoFaturamentoErro
    {
        static string Dominio = "GeracaoFaturamento";
        internal static Error ErroMeses => new Error($"{Dominio}.ExemploErro", "Apenas um exemplo");
    }

}
