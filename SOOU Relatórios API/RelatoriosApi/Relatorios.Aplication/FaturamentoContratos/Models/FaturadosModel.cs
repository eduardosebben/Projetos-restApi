using Relatorios.Dominio.Enums;

namespace Relatorios.Aplication.FaturamentoContratos.Models
{
    public class FaturadosModel
    {
        public int CodFatura { get; internal set; }
        public int CodPessoa { get; internal set; }
        public string? DesPessoa { get; internal set; }
        public decimal VlrFaturado { get; internal set; }
        public DateTime DtaEmissao { get; internal set; }
        public DateTime DtaAnaliseFinal { get; internal set; }
        public DateTime DtaAnaliseInicial { get; internal set; }
        public int NumNota { get; set; }
        public decimal VlrDesconto { get; internal set; }
        public bool TipExcluido { get; internal set; }
        public DateTime? DtaGeracao { get; internal set; }
        public TitulosFaturamentoGerado PrimeiroTitulo { get; internal set; }
        public decimal VlrDescontoTitulos { get; internal set; }
        public List<DateTime?> Vencimentos { get; internal set; } = new();
        public int? CodBancoPessoa { get; internal set; }
        public string DesBanco { get; internal set; }
        public List<FaturamentoGeracaoFaturamentoItem> Itens { get; internal set; } = new();
        public List<int> CodContratosAgrupados { get; internal set; } = new();
        public int? IndFixado { get; set; }
    }


    public class TitulosFaturamentoGerado
    {
        public int CodTitulo { get; set; }
        public int? NumNota { get; set; }
        public int? CodNota { get; set; }
        public int? CodBanco { get; internal set; }
        public string? DesTipoPagamento { get; internal set; }
        public int IndSituacao { get; internal set; }
        public int? CodTipoPagamento { get; internal set; }
        public string? DesBanco { get; internal set; }
        public bool PossuiNota => CodNota.HasValue && CodNota != 0;
    }

    public class FaturamentoGeracaoFaturamentoItem
    {
        public int? COD_LANCAMENTO { get; internal set; }
        public int? COD_CONTRATO_ITENS { get; internal set; }
        public decimal VLR_ITEM { get; internal set; }
        public DateTime? DtaEmissao { get; internal set; }
        public int HMS_FATURADOS { get; internal set; }
        public DateTime? DtaVencimento { get; internal set; }
        public int? IN_TIPO_CONTRATO { get; internal set; }
        public string? DES_PRODUTO { get; internal set; }
    }
}
