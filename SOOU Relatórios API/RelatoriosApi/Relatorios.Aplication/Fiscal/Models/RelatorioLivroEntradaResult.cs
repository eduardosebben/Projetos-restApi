namespace Relatorios.Aplication.Fiscal.Models
{
    public class RelatorioLivroEntradaResult
    {
        public List<ItemLivroEntradaResult> Itens { get; set; } = new List<ItemLivroEntradaResult>();
        public ItemLivroEntradaResult Total => new ItemLivroEntradaResult()
        {
            VlrBaseIcms = Itens.Sum(i => i.VlrBaseIcms),
            VlrIsentas = Itens.Sum(i => i.VlrIsentas),
            VlrOutras = Itens.Sum(i => i.VlrOutras),
            VlrIpi = Itens.Sum(i => i.VlrIpi),
            VlrIcms = Itens.Sum(i => i.VlrIcms),
            VlrBaseST = Itens.Sum(i => i.VlrBaseST),
            VlrST = Itens.Sum(i => i.VlrST),
            VlrBaseIpi = Itens.Sum(i=> i.VlrBaseIpi),
            VlrDesconto = Itens.Sum(i => i.VlrDesconto),
            VlrTotal = Itens.Sum(i => i.VlrTotal),
        };
    }
}
