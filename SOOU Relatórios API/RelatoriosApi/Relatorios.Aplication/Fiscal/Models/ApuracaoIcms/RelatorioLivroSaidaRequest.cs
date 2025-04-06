namespace Relatorios.Aplication.Fiscal.Models.ApuracaoIcms 
{ 
    public class RelatorioApuracaoIcmsRequest
    {
        public int CodEmpresa { get; set; }
        public DateTime? DtaInicial { get; set; }
        public DateTime? DtaFinal { get; set; }
        public bool TipDescricaoCfop { get; set; } = false;
    }
}
