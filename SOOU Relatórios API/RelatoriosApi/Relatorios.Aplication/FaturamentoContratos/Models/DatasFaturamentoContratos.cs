namespace Relatorios.Aplication.FaturamentoContratos.Models
{
    internal class DatasFaturamentoContratos
    {
        public CONTRATO Contrato { get; set; }
        public List<DatasPreCalculadasContrato> DataFranquias { get; set; } = new();
        public List<DatasPreCalculadasContrato> DataFaturas { get; set; } = new();

    }
}
