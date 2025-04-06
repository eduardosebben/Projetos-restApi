namespace Relatorios.Aplication.Fiscal.Models
{
    public class RelatorioLivroEntradaRequest
    {
        public int CodEmpresa { get; set; }
        public DateTime DtaInicial { get; set; }
        public DateTime DtaFinal { get; set; }
        public List<int> Cfops { get; set; } = new List<int>();
        public bool TipDiscriminarIpi { get; set; } = false;
        public bool TipDiscriminarValoresST { get; set; } = false;
    }
}
