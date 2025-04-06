using Relatorios.Aplication.Common.Estruturas;

namespace Relatorios.Aplication.EvolucaoCompras.Erro
{
    internal static class EvolucaoCompraErro
    {
        static string Dominio = "EvolucaoCompra";
        internal static Error ErroMeses => new Error($"{Dominio}.MesesCampoObrigatorio", "Meses deve ter um valor");
    }

}
