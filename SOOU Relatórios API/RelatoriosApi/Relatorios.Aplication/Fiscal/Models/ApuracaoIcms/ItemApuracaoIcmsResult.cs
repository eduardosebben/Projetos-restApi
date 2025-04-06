namespace Relatorios.Aplication.Fiscal.Models.ApuracaoIcms
{
    public class ItemApuracaoIcmsResult
    {

        public int CodCfop { get; set; }
        public string DesCfop { get; set; }
        public decimal Valor { get; set; }
        public decimal VlrBaseCalculo { get; set; }
        public decimal VlrImposto { get; set; }
        public decimal VlrIsentaNaoTrib { get; set; }
        public decimal VlrOutras { get; set; }

    }
}
