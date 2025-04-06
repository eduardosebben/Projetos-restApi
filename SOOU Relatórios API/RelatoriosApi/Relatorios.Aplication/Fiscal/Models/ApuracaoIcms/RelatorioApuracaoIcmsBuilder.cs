namespace Relatorios.Aplication.Fiscal.Models.ApuracaoIcms
{
    public class RelatorioApuracaoIcmsBuilder
    {
        private readonly RelatorioApuracaoIcmsResult _relatorio;

        private static ItemApuracaoIcmsResult SomarTotal(List<ItemApuracaoIcmsResult> itens)
        {
            return new ItemApuracaoIcmsResult()
            {
                Valor = itens.Sum(i => i.Valor),
                VlrBaseCalculo = itens.Sum(i => i.VlrBaseCalculo),
                VlrImposto = itens.Sum(i => i.VlrImposto),
                VlrIsentaNaoTrib = itens.Sum(i => i.VlrIsentaNaoTrib),
                VlrOutras = itens.Sum(i => i.VlrOutras),
            };
        }

        public RelatorioApuracaoIcmsBuilder(List<IGrouping<int, ItemApuracaoIcmsResult>> itens)
        {
            _relatorio = new RelatorioApuracaoIcmsResult();
            _relatorio.Itens = itens.Select(g => new ItemApuracaoIcmsResult()
            {
                CodCfop = g.Key,
                DesCfop = g.First().DesCfop,
                Valor = g.Sum(i => i.Valor),
                VlrBaseCalculo = g.Sum(i => i.VlrBaseCalculo),
                VlrImposto = g.Sum(i => i.VlrImposto),
                VlrIsentaNaoTrib = g.Sum(i => i.VlrIsentaNaoTrib),
                VlrOutras = g.Sum(i => i.VlrOutras),
            }).ToList();
        }

        public  RelatorioApuracaoIcmsResult CriarRelatorioSaidas()
        {
            _relatorio.TotalGeral = SomarTotal(_relatorio.Itens.ToList());

            var cfopDentroEstado = _relatorio.Itens.Where(i => i.CodCfop < 6000).ToList();
            var cfopForaEstado = _relatorio.Itens.Where(i => i.CodCfop > 7000).ToList();
            var cfopExterior = _relatorio.Itens.Except(cfopDentroEstado).Except(cfopForaEstado).ToList();

            _relatorio.TotalExterior = SomarTotal(cfopDentroEstado);
            _relatorio.TotalDentroEstado = SomarTotal(cfopForaEstado);
            _relatorio.TotalForaEstado = SomarTotal(cfopExterior);

            return _relatorio;

        }

        public RelatorioApuracaoIcmsResult CriarRelatorioEntradas()
        {
            _relatorio.TotalGeral = SomarTotal(_relatorio.Itens.ToList());

            var cfopDentroEstado = _relatorio.Itens.Where(i => i.CodCfop < 2000).ToList();
            var cfopForaEstado = _relatorio.Itens.Where(i => i.CodCfop > 3000).ToList();
            var cfopExterior = _relatorio.Itens.Except(cfopDentroEstado).Except(cfopForaEstado).ToList();

            _relatorio.TotalDentroEstado = SomarTotal(cfopDentroEstado);
            _relatorio.TotalForaEstado = SomarTotal(cfopForaEstado);
            _relatorio.TotalExterior = SomarTotal(cfopExterior);

            return _relatorio;
        }
    }
}
