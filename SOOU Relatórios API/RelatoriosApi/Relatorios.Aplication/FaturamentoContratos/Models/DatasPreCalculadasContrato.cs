namespace Relatorios.Aplication.FaturamentoContratos.Models
{
    struct DatasPreCalculadasContrato
    {
        public DateTime DtaEmissao { get; }
        public DateTime DtaConsultaInicial { get; }
        public DateTime DtaConsultaFinal { get; }

        public DatasPreCalculadasContrato(DateTime dtaGeracao, DateTime dtaConsultaInicial, DateTime dtaConsultaFinal)
        {
            DtaEmissao = dtaGeracao;
            DtaConsultaInicial = dtaConsultaInicial;
            DtaConsultaFinal = dtaConsultaFinal;
        }
    }
}
