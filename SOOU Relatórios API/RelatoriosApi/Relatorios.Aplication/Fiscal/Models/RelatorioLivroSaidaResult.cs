namespace Relatorios.Aplication.Fiscal.Models
{
    public class RelatorioLivroSaidaResult
    {
        public List<ItemLivroSaidaResult> Itens { get; set; } = new List<ItemLivroSaidaResult>();
        public ItemLivroEntradaResult Total => new ItemLivroEntradaResult()
        {
            VlrBaseIcms = Itens.Sum(i => i.VlrBaseIcms),
            VlrOutras = Itens.Sum(i => i.VlrOutras),
            VlrIpi = Itens.Sum(i => i.VlrIpi),
            VlrIcms = Itens.Sum(i => i.VlrIcms),
            VlrBaseST = Itens.Sum(i => i.VlrBaseST),
            VlrST = Itens.Sum(i => i.VlrST),
            VlrBaseIpi = Itens.Sum(i => i.VlrBaseIpi),
            VlrDesconto = Itens.Sum(i => i.VlrDesconto),
            VlrTotal = Itens.Sum(i => i.VlrTotal),
        };
    }
}
