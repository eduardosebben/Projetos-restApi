using Relatorios.Dominio.Enums;

namespace Relatorios.Aplication.FaturamentoContratos.Models
{

    public class PreFaturamento
    {
        public string? DesPessoa { get; set; }
        public string? DesRazaoSocial { get; set; }
        public int CodPessoa { get; set; }
        public CONTRATO Contrato { get; set; }
        public TIPO_PAGAMENTO_FATURAMENTO TipoPagtoSugerido { get; set; }
        public BANCO_FATURAMENTO? BancoSugerido { get; set; }
        public int CodConvenioContrato { get; set; }
        public string DesConvenioContrato { get; set; }

        public bool TipFaturado { get; set; }
        public bool TipFaturaFutura { get; set; }
        public bool TipDescritivo { get; set; }

        public DateTime DtaAnaliseInicial { get; set; }
        public DateTime DtaAnaliseFinal { get; set; }
        public DateTime DtaEmissao { get; set; }
        public DateTime? DtaGeracao { get; set; }
        public int NumNota { get; set; }
        public decimal VlrTotal { get; set; }
        public decimal VlrTotalDesconto => Math.Round(ListaItens?.Sum(x => x.VlrDesconto) ?? 0, 2);
        public decimal VlrLiquido => VlrTotal - VlrTotalDesconto;

        public BancoFranquia BancoFranquia { get; set; }
        public List<DateTime> DtaVencimentos { get; set; } = new();
        public List<BancoFranquia> ListaBancoFranquia { get; set; } = new();
        public List<CONTRATO> ContratosAgrupados { get; set; } = new();
        public List<ItemFaturamento> ListaItens { get; set; } = new();
        public List<ItemFaturamento> ListaItensNoPeriodo { get; set; } = new();
        public List<ItemFaturamento> ListaItensAteOPeriodo { get; set; } = new();


        public PreFaturamento()
        {

        }


        public PreFaturamento(CONTRATO contrato, DateTime dtaEmissao)
        {
            CodPessoa = contrato.COD_PESSOA;
            DesPessoa = contrato.DES_PESSOA;
            DesRazaoSocial = contrato.DES_RAZAO_SOCIAL;
            DtaEmissao = dtaEmissao;
            TipFaturado = false;
        }


        public PreFaturamento(
            CONTRATO pessoa,
            DateTime dtaEmissao,
            List<ItemFaturamento> itens,
            List<ItemFaturamento> itensNoPeriodo,
            BancoFranquia bancoFranquia,
            List<ItemFaturamento> listaItensAteOPeriodo)
            : this(pessoa, dtaEmissao)
        {
            ListaItens = itens;
            ListaItensNoPeriodo = itensNoPeriodo;
            ListaItensAteOPeriodo = listaItensAteOPeriodo;

            BancoFranquia = bancoFranquia;

            AtualizarTotal();
        }

        public PreFaturamento(ItemFaturamento item)
        {
            CodPessoa = item.CodPessoa;
            DesPessoa = item.DesPessoa;
            DesRazaoSocial = item.DesRazaoSocial;
            DtaEmissao = item.DtaEmissao;
            TipFaturado = false;

            AdicionarItem(item);
        }

        internal void AdicionarItem(ItemFaturamento item)
        {
            ListaItens.Add(item);
            AtualizarTotal();
        }

        internal void AtualizarTotal()
        {
            VlrTotal = Math.Round(ListaItens?.Sum(x => x.VlrTotal) ?? 0, 2);
        }

        internal void AdicionarCodContratoAgruado(params CONTRATO[] contratos)
        {
            foreach (var c in contratos)
            {
                if (!ContratosAgrupados.Contains(c))
                    ContratosAgrupados.Add(c);
            }
        }

        internal void AdicionarVencimentos(params DateTime[] vencimentos)
        {
            foreach (var vencimento in vencimentos)
            {
                DtaVencimentos.Add(vencimento);
            }
        }

    }


    /// <summary>
    /// Item faturamento podem estar agrupando varios contratos
    /// </summary>
    public class ItemFaturamento
    {
        public int CodLancamento { get; set; }
        public int? CodContratoItens { get; set; }
        public int CodPessoa { get; set; }
        public string DesPessoa { get; set; }
        public string DesRazaoSocial { get; set; }
        public int? CodProduto { get; set; }
        public string DesProduto { get; set; }
        public decimal VlrTotal { get; set; }
        public decimal VlrLancamento { get; set; }
        public decimal VlrNaoConsiderarFaturamento { get; set; }
        public decimal VlrDesconto { get; set; }
        public int Qtde { get; set; }
        public DateTime DtaEmissao { get; set; }
        public DateTime DtaVencimento { get; set; }
        public int HmsFaturadas { get; set; }
        public bool IsItemContrato { get; set; }
        public bool IsLancamento { get; set; }
        public List<DateTime> Vencimentos { get; set; } = new();
        public int? CodTipoPagamento { get; set; }
        public List<BancoFranquia> BancoFranquia { get; set; } = new();
        public int? IndTipoLancamento {  get; set; }

        private ResultadoAnaliseLancamentos _LANCAMENTO { get; set; }
        private CONTRATO _CONTRATO { get; set; }



        public CONTRATO GetContrato()
        {
            return _CONTRATO;
        }

        public ResultadoAnaliseLancamentos GetLancamento()
        {
            return _LANCAMENTO;
        }


        public int GetTotalFranquiaTipo(TipoFranquiaContrato tipo)
        {
            if (CodProduto == null)
                return 0;

            return BancoFranquia.SelectMany(b => b.ProdutosFranquias).Where(p =>
                p.ItemContrato.COD_PRODUTO == CodProduto
                && p.ItemContrato.IND_TIPO_CONTRATO == (int)tipo)
                .Sum(p => p.QtdTotalFranquia);
        }



        public ItemFaturamento()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lancamento"></param>
        /// <param name="bancoFranquia">Utiliza-se dentro dos contadores do relatório descritivo</param>
        public ItemFaturamento(ResultadoAnaliseLancamentos lancamento, List<BancoFranquia> bancoFranquia = null, CONTRATO contrato = null, bool itemFixoContrato = false)
        {
            CodLancamento = lancamento.CodLancamento;
            CodContratoItens = lancamento.CodItemContrato;
            BancoFranquia = bancoFranquia;
            CodPessoa = lancamento.CodPessoa ?? 0;
            DesPessoa = lancamento.DesPessoa;
            DesRazaoSocial = lancamento.DesRazaoSocial;
            DtaEmissao = lancamento.DtaCobranca;
            VlrTotal = lancamento.VlrTotal;

            VlrNaoConsiderarFaturamento = lancamento.VlrNaoConsiderarFaturamento;

            VlrDesconto = lancamento.VlrDesconto;
            Qtde = lancamento.TotalMinutosFaturados;
            HmsFaturadas = lancamento.TotalMinutosFaturados;

            var dtaVencimento = lancamento.DtaLancamento;
            if (dtaVencimento == null)
                dtaVencimento = DtaEmissao;

            DtaVencimento = Convert.ToDateTime(dtaVencimento);
            IsLancamento = itemFixoContrato;

            Vencimentos = lancamento.Vecimentos;
            CodTipoPagamento = lancamento.CodTipoPagamento;
            VlrLancamento = lancamento.VlrLancamento;

            DesProduto = lancamento.DesProduto;
            IndTipoLancamento = lancamento.Lancamento?.IND_TIPO_LANCAMENTO;

            _LANCAMENTO = lancamento;
            _CONTRATO = contrato;
        }



        public ItemFaturamento(ITEM_CONTRATO x, List<BancoFranquia> bancoFranquia = null, CONTRATO contrato = null)
        {
            CodProduto = x.COD_PRODUTO;
            VlrTotal = x.VLR_CONTRATO ?? 0;
            CodContratoItens = x.COD_CONTRATO_ITENS;
            Qtde = 1;
            BancoFranquia = bancoFranquia;
            DesProduto = x.DES_SERVICO_NOTA ?? x.DES_PRODUTO!;
            IsItemContrato = true;
            IndTipoLancamento = x.IND_TIPO_CONTRATO;
            _CONTRATO = contrato;
        }
    }




    public class BancoFranquia
    {
        public CONTRATO Contrato { get; set; }
        public int QtdTotalFranquia { get; set; }
        public int QtdRestante { get; set; }
        public List<ItemBancoFranquia> ProdutosFranquias { get; set; }

        public BancoFranquia(CONTRATO contrato)
        {
            Contrato = contrato;
            QtdTotalFranquia = contrato.QTD_FRANQUIA ?? 0;
            QtdRestante = QtdTotalFranquia;
            ProdutosFranquias = contrato.ITEMS.Select(x => new ItemBancoFranquia(x)).ToList();
        }

        public int RetornarQtdeRestanteFranquia(int codProduto)
        {
            return ProdutosFranquias.FirstOrDefault(x => x.ItemContrato.COD_PRODUTO == codProduto)?.QtdRestante ?? 0;
        }
    }

    public class ItemBancoFranquia
    {
        public ITEM_CONTRATO ItemContrato { get; set; }
        public int QtdTotalFranquia { get; set; }
        public int QtdRestante { get; set; }

        public ItemBancoFranquia(ITEM_CONTRATO item)
        {
            ItemContrato = item;
            QtdTotalFranquia = item.QTD_FRANQUIA ?? 0;
            QtdRestante = QtdTotalFranquia;
        }
    }

    public abstract class ResultadoAnaliseFaturamento
    {
        public virtual int TotalMinutosTrabalhados { get; set; }
        public virtual int TotalMinutosCobrados { get; set; }
        public virtual int TotalMinutosFaturados { get; set; }
        public virtual int TotalFranquiaHoras { get; set; }
        public decimal VlrDesconto { get; set; }
        public decimal VlrTotal { get; set; }
        public decimal VlrLiquido => VlrTotal - VlrDesconto;
        public decimal VlrLancamento { get; set; }
        public decimal VlrNaoConsiderarFaturamento { get; set; }
    }

    public class ResultadoAnaliseCliente : ResultadoAnaliseFaturamento
    {
        public int CodPessoa { get; set; }
        public string DesPessoa { get; set; }
        public DateTime DtaReajuste { get; set; }
        public List<ResultadoAnaliseContratos> ListaContratos { get; set; }
        public List<ResultadoAnaliseLancamentos> ListaLancamentos { get; set; }

        public ResultadoAnaliseCliente(IEnumerable<ResultadoAnaliseContratos> analiseComContrato, IEnumerable<ResultadoAnaliseLancamentos> analiseSemContrato)
        {

            var itemComContrato = analiseComContrato.FirstOrDefault();
            if (itemComContrato != null)
            {
                CodPessoa = itemComContrato.Contrato.COD_PESSOA;
                DesPessoa = itemComContrato.Contrato.DES_PESSOA;
            }
            else
            {
                var itemSemContrato = analiseSemContrato.FirstOrDefault();
                CodPessoa = itemSemContrato?.CodPessoa ?? 0;
                DesPessoa = itemSemContrato?.DesPessoa;
            }

            ListaLancamentos = analiseSemContrato.ToList();

            ListaContratos = analiseComContrato.ToList();

            CalcularTotais();
        }

        public void CalcularTotais()
        {
            TotalMinutosTrabalhados = ListaLancamentos.Sum(x => x.TotalMinutosTrabalhados)
                + ListaContratos.Sum(x => x.TotalMinutosTrabalhados);

            TotalMinutosCobrados = ListaLancamentos.Sum(x => x.TotalMinutosCobrados)
                + ListaContratos.Sum(x => x.TotalMinutosCobrados);

            TotalMinutosFaturados = ListaLancamentos.Sum(x => x.TotalMinutosFaturados)
                + ListaContratos.Sum(x => x.TotalMinutosFaturados);

            VlrTotal = ListaLancamentos.Sum(x => x.VlrTotal)
                + ListaContratos.Sum(x => x.VlrTotal);

            VlrDesconto = ListaLancamentos.Sum(x => x.VlrDesconto)
                + ListaContratos.Sum(x => x.VlrDesconto);

            VlrNaoConsiderarFaturamento = ListaLancamentos.Sum(x => x.VlrNaoConsiderarFaturamento)
                + ListaContratos.Sum(x => x.VlrNaoConsiderarFaturamento);
        }


        public ResultadoAnaliseCliente(IEnumerable<ResultadoAnaliseContratos> analiseComContrato)
        {
            var itemComContrato = analiseComContrato.FirstOrDefault();
            if (itemComContrato != null)
            {
                CodPessoa = itemComContrato.Contrato.COD_PESSOA;
                DesPessoa = itemComContrato.Contrato.DES_PESSOA;
            }

            ListaContratos = analiseComContrato.ToList();

            CalcularTotais();
        }

        public ResultadoAnaliseCliente(IEnumerable<ResultadoAnaliseLancamentos> analiseSemContrato)
        {
            var itemSemContrato = analiseSemContrato.FirstOrDefault();

            if (itemSemContrato != null)
            {
                CodPessoa = itemSemContrato?.CodPessoa ?? 0;
                DesPessoa = itemSemContrato?.DesPessoa;
            }

            ListaLancamentos = analiseSemContrato.ToList();

            CalcularTotais();
        }

        public void AdicionarAnaliseComContratos(IEnumerable<ResultadoAnaliseContratos> analiseComContrato)
        {
            ListaContratos = analiseComContrato.ToList();

            CalcularTotais();
        }


    }

    public class ResultadoAnaliseContratos : ResultadoAnaliseFaturamento
    {
        public int CodPessoa { get; set; }
        public int CodContrato { get; set; }
        public CONTRATO Contrato { get; set; }

        public DateTime DtaReajuste { get; set; }
        public DateTime DtaAnaliseInicial { get; set; }
        public DateTime DtaAnaliseFinal { get; set; }
        public DateTime DtaEmissao { get; set; }
        public DateTime? DtaUltimoReajuste { get; set; }
        public int TotalFranquiaMinutos { get; set; }
        public int TotalFranquiaQuantidade { get; set; }
        public bool TipAgrupa { get; set; }
        public bool TipAgrupouContrato { get; set; }
        public bool TipPeriodoCobrancaFranquia { get; set; }
        public BancoFranquia BancoFranquia { get; set; }
        public decimal VlrContrato { get; set; }
        public bool TipFranquia { get; set; }

        public List<BancoFranquia> ListaFranquias { get; set; }

        public List<ResultadoAnaliseLancamentos> ListaLancamentos { get; set; } = new();
        public List<ResultadoAnaliseLancamentos> ListaLancamentosNoPeriodo { get; set; } = new();
        public List<ResultadoAnaliseLancamentos> ListaLancamentosAteOPeriodo { get; set; } = new();
        public List<ITEM_CONTRATO> ListaItensValorContrato { get; set; }
        public List<CONTRATO> ContratosAgrupados { get; set; }


        public ResultadoAnaliseContratos()
        {

        }

        public void AdicionarContratos(params CONTRATO[] contratos)
        {
            if (ContratosAgrupados == null)
                ContratosAgrupados = new List<CONTRATO>();

            foreach (var contrato in contratos)
            {
                ContratosAgrupados.Add(contrato);
            }
        }


    }



    public class ResultadoAnaliseLancamentos : ResultadoAnaliseFaturamento
    {
        public int? CodPessoa { get; set; }
        public string DesPessoa { get; set; }
        public string DesRazaoSocial { get; set; }
        public int CodProduto { get; set; }

        public string DesProduto { get; set; }


        public int CodLancamento { get; set; }
        public int? CodItemContrato { get; set; }
        public DateTime DtaCobranca { get; set; }
        public DateTime? DtaLancamento { get; set; }
        public bool TipFaturado { get; set; }
        public bool TipErro { get; set; }
        public bool TipDescritivo { get; set; }
        public bool TipAnalisado { get; set; }
        public List<DateTime> Vecimentos { get; set; } = new();

        public int? CodTipoPagamento { get; set; }

        public bool TipConsiderarFranquia { get; set; }
        public bool TipCobrancaFaturamento { get; set; }
        public int? IndTipoLancamento { get; set; }


        public LANCAMENTOS_FATURAMENTO Lancamento { get; set; }

        public ResultadoAnaliseLancamentos()
        {

        }


        public ResultadoAnaliseLancamentos(LANCAMENTOS_FATURAMENTO lancamento)
        {
            TipAnalisado = lancamento.TIP_ANALISADO ?? false;

            var hmsLancamento = lancamento.HMS_LANCAMENTO ?? 0;
            if (lancamento.HMS_AJUSTADA > 0)
                hmsLancamento = lancamento.HMS_AJUSTADA ?? 0;

            CodLancamento = lancamento.COD_LANCAMENTO;
            CodLancamento = lancamento.COD_LANCAMENTO;

            CodProduto = lancamento.COD_PRODUTO;
            DesProduto = lancamento.DES_PRODUTO;
            CodPessoa = lancamento.COD_PESSOA;
            DesPessoa = lancamento.DES_PESSOA!;
            DesRazaoSocial = lancamento.DES_RAZAO_SOCIAL!;
            Vecimentos = lancamento.LISTA_VENCIMENTOS;
            CodTipoPagamento = lancamento.COD_TIPO_PAGAMENTO_PESSOA;
            DtaCobranca = lancamento.DTA_COBRANCA;
            TotalMinutosTrabalhados = lancamento.HMS_LANCAMENTO ?? 0;
            TotalMinutosCobrados = hmsLancamento;
            TotalMinutosFaturados = hmsLancamento;

            TipConsiderarFranquia = lancamento.TIP_CONSIDERAR_FRANQUIA;
            TipCobrancaFaturamento = lancamento.TIPO_COBRANCA_FATURAMENTO.GetValueOrDefault();
            IndTipoLancamento = lancamento.IND_TIPO_LANCAMENTO;

            Lancamento = lancamento;
        }



    }


}
