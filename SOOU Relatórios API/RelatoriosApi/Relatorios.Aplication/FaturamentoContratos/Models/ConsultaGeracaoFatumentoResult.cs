using Relatorios.Aplication.FaturamentoContratos.Services;
using Relatorios.Dominio.Enums;

namespace Relatorios.Aplication.FaturamentoContratos.Models
{
    public class ConsultaGeracaoFatumentoResult
    {
        public string DesGuid { get; set; }
        public int? CodContrato { get; set; }
        public int CodPessoa { get; set; }
        public int CodTipoPagamento { get; set; }
        public int CodBanco { get; set; }
        public int? CodBancoConvenio { get; set; }
        public int? CodBancoSugerido { get; set; }
        public string DesBanco { get; set; }
        public string? DesBancoSugerido { get; set; }
        public string DesTipoPagamento { get; set; }
        public string DesPessoa { get; set; }
        public decimal VlrFaturado { get; set; }
        public decimal VlrDesconto { get; set; }
        public decimal VlrLiquido { get; set; }
        public string DesSituacao { get; set; }
        public int NumNota { get; set; }
        public TipoSituacaoNota? IndSituacaoNota { get; set; }
        public bool TipFaturado { get; set; }
        public bool MarcadaParaFaturar { get; set; }
        public DateTime? DtaGeracaoDt { get; set; }
        public DateTime? DtaEmissaoDt { get; set; }
        public DateTime? DtaAnaliseInicialDt { get; set; }
        public DateTime? DtaAnaliseFinalDt { get; set; }
        public int CodFatura { get; set; }
        public bool TipEmAtraso { get; set; }
        public bool TipExcluido { get; set; }
        public bool ExibirDescritivo { get; set; }
        public int CodConvenioContrato { get; set; }
        public string DesConvenioContrato { get; set; }

        public List<DateTime?> ListaVencimentos { get; set; } = new();
        public List<int> CodigosContratosAgrupados { get; set; } = new();

        public List<ConsultaGeracaoFaturamentoItem> ListaItens { get; set; } = new();
        public List<ConsultaGeracaoFaturamentoItem> ListaItensFuturos { get; set; } = new();

        public List<FaturamentoContrato> Contratos { get; set; } = new List<FaturamentoContrato>();
        public InfoFranquia InfoFranquia { get; set; }
        public int IndRecorrenciaFranquia { get; set; }
        public string DesServico { get; set; } = string.Empty;
        public int IndFixado { get; set; }

        public ConsultaGeracaoFatumentoResult(PreFaturamento resultado) 
        {
            DesGuid = Guid.NewGuid().ToString();
            DesPessoa = resultado.DesPessoa;
            DtaEmissaoDt = resultado.DtaEmissao;
            DtaGeracaoDt = resultado.DtaGeracao;
            VlrFaturado = resultado.VlrTotal;
            VlrDesconto = resultado.VlrTotalDesconto;
            VlrLiquido = resultado.VlrLiquido;
            CodBancoConvenio = resultado.Contrato?.COD_CONVENIO_BANCARIO;
            TipFaturado = resultado.TipFaturado;
            NumNota = resultado.NumNota;
            CodPessoa = resultado.CodPessoa;
            CodContrato = resultado.Contrato?.COD_CONTRATO ?? 0;
            ListaItens = resultado.ListaItens.Select(x => new ConsultaGeracaoFaturamentoItem(x)).ToList() ?? ListaItens;
            ListaItensFuturos = resultado.ListaItensNoPeriodo.Select(x => new ConsultaGeracaoFaturamentoItem(x)).ToList() ?? ListaItens;


            DtaAnaliseFinalDt = resultado.DtaAnaliseFinal;
            DtaAnaliseInicialDt = resultado.DtaAnaliseInicial;
            TipExcluido = false;
            ExibirDescritivo = resultado.TipDescritivo;
            CodigosContratosAgrupados = resultado.ContratosAgrupados.Select(x => x.COD_CONTRATO).ToList();
            
            TipEmAtraso = resultado.DtaVencimentos.FirstOrDefault() < DateTime.Today;

            ListaVencimentos = resultado.DtaVencimentos.Select(d => (DateTime?)d).ToList();

            IndRecorrenciaFranquia = resultado.Contrato?.IND_RECORRENCIA_FRANQUIA ?? 0;

            if (resultado.TipoPagtoSugerido != null)
            {
                CodTipoPagamento = resultado.TipoPagtoSugerido.CODIGO;
                DesTipoPagamento = resultado.TipoPagtoSugerido.DESCRICAO ?? string.Empty;
            }

            if (resultado.BancoSugerido != null)
            {
                CodBanco = resultado.BancoSugerido.CodBanco;
                DesBanco = resultado.BancoSugerido.DesBanco!;
                DesBancoSugerido = resultado.BancoSugerido.DesBanco!;
                CodBancoSugerido = resultado.BancoSugerido.CodBanco;

            }

            CodConvenioContrato = resultado.CodConvenioContrato;
            DesConvenioContrato = resultado.DesConvenioContrato;

            DesSituacao = RetornaDesSituacao();


            Contratos = resultado.ContratosAgrupados.Select(c => new FaturamentoContrato(c)).ToList();

            InfoFranquia = new InfoFranquia()
            {
                QtdRestante = resultado.BancoFranquia?.QtdRestante ?? 0,
                QtdTotalFranquia = resultado.BancoFranquia?.QtdTotalFranquia ?? 0
            };

            if (ListaItens.Any(x => x.IndTipoLancamento == (int)TipoLancamento.Valor))
            {
                DesServico = string.Join(", ", ListaItens.Where(x => x.IndTipoLancamento == (int)TipoLancamento.Valor).Select(x => x.DesProduto).Distinct());
            }

            IndFixado = resultado.Contrato?.IND_FIXADO ?? (int)IndicadorTipoConbranca.PosFixado;
        }

        public ConsultaGeracaoFatumentoResult(FaturadosModel fatura)
        {
            DesGuid = Guid.NewGuid().ToString();
            CodFatura = fatura.CodFatura;
            CodPessoa = fatura.CodPessoa;
            DesPessoa = fatura.DesPessoa;
            VlrFaturado = fatura.VlrFaturado;
            DtaEmissaoDt = fatura.DtaEmissao;
            DtaAnaliseFinalDt = fatura.DtaAnaliseFinal;
            DtaAnaliseInicialDt = fatura.DtaAnaliseInicial;
            VlrDesconto = fatura.VlrDescontoTitulos;
            TipExcluido = fatura.TipExcluido;
            VlrDesconto = fatura.VlrDesconto;
            VlrLiquido = VlrFaturado - VlrDesconto;
            TipFaturado = true;
            DtaGeracaoDt = fatura.DtaGeracao;
            ListaVencimentos = fatura.Vencimentos.ToList();
            CodigosContratosAgrupados = fatura.CodContratosAgrupados;

            if (fatura.Itens.Any() == true)
            {
                ListaItens = fatura
                    .Itens
                    .Select((faturaItem) => new ConsultaGeracaoFaturamentoItem(faturaItem)).ToList();
            }

            var primeiroTitulo = fatura.PrimeiroTitulo;

            if(primeiroTitulo != null)
            {
                if (fatura.PrimeiroTitulo.PossuiNota)
                    IndSituacaoNota = (TipoSituacaoNota)primeiroTitulo.IndSituacao; 

                NumNota = fatura.PrimeiroTitulo?.NumNota ?? 0;
                DesTipoPagamento = primeiroTitulo?.DesTipoPagamento ?? string.Empty;
                CodBanco = primeiroTitulo?.CodBanco ?? 0; 
                CodTipoPagamento = primeiroTitulo?.CodTipoPagamento ?? 0;
            }

            DesBanco = (primeiroTitulo?.DesBanco ?? fatura?.DesBanco)!;

            DesSituacao = RetornaDesSituacao();

            if (ListaItens.Any(x => x.IndTipoLancamento == (int)TipoLancamento.Valor))
            {
                DesServico = string.Join(", ", ListaItens.Where(x => x.IndTipoLancamento == (int)TipoLancamento.Valor).Select(x => x.DesProduto).Distinct());
            }
            IndFixado = fatura?.IndFixado ?? (int)IndicadorTipoConbranca.PosFixado;
        }


        private string RetornaDesSituacao()
        {
            if (TipExcluido)
                return "Excluído";

            if (TipFaturado)
                return "Faturado";

            if (TipEmAtraso)
                return "Em atraso";

            return "Não Faturado";
        }
    }


    public class FaturamentoContrato
    {
        public int CodContrato { get; set; }
        public string NumContrato { get; set; }
        public int? TipoFranquia { get; set; }
        public int? QtdFranquia { get; set; }
        public decimal? VlrContrato { get; set; }
        public List<FaturamentoContratoItens> ItensContrato { get; set; } = new();


        public FaturamentoContrato()
        {

        }

        public FaturamentoContrato(CONTRATO c)
        {
            CodContrato = c.COD_CONTRATO;
            NumContrato = c.NUM_CONTRATO;
            TipoFranquia = c.IND_TIPO_FRANQUIA;
            QtdFranquia = c.QTD_FRANQUIA;
            VlrContrato = c.VLR_CONTRATO;

            ItensContrato = c.ITEMS.Select(x => new FaturamentoContratoItens(x)).ToList();
        }
    }

    public class FaturamentoContratoItens
    {
        public int CodItem { get; set; }
        public int? TipoContrato { get; set; }
        public int? QtdFranquia { get; set; }


        public FaturamentoContratoItens()
        {

        }

        public FaturamentoContratoItens(ITEM_CONTRATO x)
        {
            CodItem = x.COD_CONTRATO_ITENS;
            TipoContrato = x.IND_TIPO_CONTRATO;
            QtdFranquia = x.QTD_FRANQUIA;
        }
    }

    public class InfoFranquia
    {
        public int QtdTotalFranquia { get; set; }
        public int QtdRestante { get; set; }
        public int HmsJaUtilizada => QtdTotalFranquia - QtdRestante;

        public InfoFranquia()
        {
                
        }
    }


}
