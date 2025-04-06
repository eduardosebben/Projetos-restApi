namespace Relatorios.Aplication.Fiscal.Models
{
    public class ItemLivroSaidaResult
    {
        public int Numero { get; internal set; }
        public string? Serie { get; internal set; }

        public int CodEmpresa { get; internal set; }
        public int CodNota { get; internal set; }
        public bool IsDevolucao { get; internal set; }
        public decimal VlrTotal { get; internal set; }
        public decimal VlrDesconto { get; internal set; }
        public decimal VlrIpi { get; internal set; }
        public decimal VlrBaseIpi { get; internal set; }


        public decimal VlrIcms { get; internal set; }
        public decimal VlrBaseIcms { get; internal set; }

        public decimal VlrST { get; internal set; }
        public decimal VlrBaseST { get; internal set; }
        public decimal PerIcms { get; internal set; }

        public DateTime? DtaEmissao { get; internal set; }
        public DateTime? DtaEntrada { get; internal set; }
        public decimal? VlrOutras { get; internal set; }
        public string? DesObservacao => IsCancelada || IsCancelada 
            ? DesObservacaoCanceladaDenegada 
            : string.Join(", ",Mensagens);

        public EmitenteModel Emitente { get; internal set; } = new EmitenteModel();

        public int? CodOperacaoFiscalCabecalho { get; set; }
        public int? CfopCabecalho { get; set; }

        public bool IsCancelada { get; set; }


        internal string? DesObservacaoCanceladaDenegada { get; set; }
        internal List<string> Mensagens { get; set; } = new();

        public class EmitenteModel
        {
            public string DesEmitente { get; set; }
            public int Codigo { get; set; }
            public string SiglaUF { get; set; }

            public EmitenteModel()
            {

            }
        }

    }
}
