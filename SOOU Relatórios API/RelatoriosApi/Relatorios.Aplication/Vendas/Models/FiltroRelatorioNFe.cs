using Relatorios.Dominio.Enums;

namespace Relatorios.Aplication.Vendas.Models
{
    public class FiltroRelatorioNFe
    {
        public int codEmpresa { get; set; }
        public DateTime? dtaEmissaoInicial { get; set; }
        public DateTime? dtaEmissaoFinal { get; set; }
        public DateTime? dtaAutorizacaoInicial { get; set; }
        public DateTime? dtaAutorizacaoFinal { get; set; }
        public string? desSerie { get; set; }
        public int? codCliente { get; set; } = 0;
        public int? numNotaInicial { get; set; }
        public int? numNotaFinal { get; set; }
        public List<TipoSituacaoNota> listaStatus { get; set; } = new();
        public List<TipoNotaFiscal> listaModelos { get; set; } = new();
        public string? desCliente { get; set; }
        public List<int> Representantes { get; set; } = new();
        public bool apenasVendas { get; set; } = false;
    }

}
