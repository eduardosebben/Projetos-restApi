using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;

namespace Relatorios.Aplication.FaturamentoContratos.Models
{
    public class ConsultaGeracaoFaturamentoItem
    {
        public int? CodLancamento { get; set; }
        public int? CodContratoItens { get; set; }
        public int Quantidade { get; set; }
        public decimal VlrTotal { get; set; }
        public DateTime DtaEmissao { get; set; }
        public DateTime DtaVencimento { get; set; }
        public int HmsFaturados { get; set; }
        public decimal VlrLancamento { get; set; }
        public int? CodProduto { get; set; }
        public string DesProduto { get; set; }
        public int? CodContrato { get; set; }
        public int QtdTotalHorasFranquia { get; set; }
        public int? HmsAjustada { get; set; }
        public int? HmsLancamento { get; set; }
        public int TipoLancamento { get; set; }
        public decimal VlrDesconto { get; set; }
        public bool? TipCobrancaFaturamento { get; set; }
        public decimal VlrNaoConsiderarFaturamento { get; set; }
        public string DesSolicitante { get; set; }
        public string DesObservacao { get; set; }
        public DateTime DtaCobranca { get; set; }
        public List<string?> ListaObservacoesResolutivas { get; set; } = new List<string>();
        public bool IsItemFixoContrato { get; set; }
        public int? IndTipoLancamento { get; set; }


        public ConsultaGeracaoFaturamentoItem()
        {
        }

        public ConsultaGeracaoFaturamentoItem(ItemFaturamento item)
        {
            CodLancamento = item.CodLancamento;
            CodContratoItens = item.CodContratoItens;
            Quantidade = item.Qtde;
            DtaEmissao = item.DtaEmissao;
            DtaVencimento = item.DtaVencimento;
            VlrTotal = item.VlrTotal;
            VlrLancamento = item.VlrLancamento;
            HmsFaturados = item.HmsFaturadas;
            VlrDesconto = item.VlrDesconto;
            VlrNaoConsiderarFaturamento = item.VlrNaoConsiderarFaturamento;
            QtdTotalHorasFranquia = item.GetTotalFranquiaTipo(TipoFranquiaContrato.Horas);
            CodProduto = item.CodProduto;
            DesProduto = item.DesProduto;
            IsItemFixoContrato = item.IsItemContrato;
            IndTipoLancamento = item.IndTipoLancamento;

            var contrato = item.GetContrato();
            CodContrato = contrato?.COD_CONTRATO;

            var analiseLancamento = item.GetLancamento();
            var lancamento = analiseLancamento?.Lancamento;
            if(lancamento != null)
            {
                HmsAjustada = lancamento.HMS_AJUSTADA;
                HmsLancamento = lancamento.HMS_LANCAMENTO;
                TipoLancamento = lancamento.IND_TIPO_LANCAMENTO ?? 0;
                TipCobrancaFaturamento = lancamento.TIPO_COBRANCA_FATURAMENTO;
                DesSolicitante = lancamento.DES_SOLICITANTE!;
                DesObservacao = lancamento.DES_OBSERVACAO!;
                DtaCobranca = lancamento.DTA_COBRANCA;
                ListaObservacoesResolutivas = lancamento.ListaObservacoesResolutivas;
            }
        }

        public ConsultaGeracaoFaturamentoItem(FaturamentoGeracaoFaturamentoItem item)
        {
            //não temos como refazer o faturamento como da primeira
            //vez somente alguns campos estão disponiveis

            CodLancamento = item.COD_LANCAMENTO;
            CodContratoItens = item.COD_CONTRATO_ITENS;
            Quantidade = 0;
            VlrTotal = item.VLR_ITEM;
            VlrLancamento = item.VLR_ITEM;
            DtaEmissao = item.DtaEmissao ?? DateTime.Now; 
            DtaVencimento = item.DtaVencimento ?? DateTime.Today; 
            HmsFaturados = item.HMS_FATURADOS;
            IndTipoLancamento = item.IN_TIPO_CONTRATO;
            DesProduto = item.DES_PRODUTO;

        }


    }


}
