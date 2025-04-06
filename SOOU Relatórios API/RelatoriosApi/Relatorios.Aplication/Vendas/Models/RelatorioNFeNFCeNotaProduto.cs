namespace Relatorios.Aplication.Vendas.Models
{
    public class RelatorioNFeNFCeNotaProduto
    {
        public int codItem { get; set; }
        public int numSequencia { get; set; }
        public string codSKU { get; set; }
        public string desProduto { get; set; }
        public string unidadeMedida { get; set; }
        public string desOperacaoFiscal { get; set; }
        public decimal? qtdProduto { get; set; }
        public decimal? valorUnitario { get; set; }
        public decimal? valorBaseICMS { get; set; }
        public decimal? valorICMS { get; set; }
        public decimal? valorBaseST { get; set; }
        public decimal? valorST { get; set; }
        public decimal? valorSTRetido { get; set; }
        public decimal? valorIPI { get; set; }
        public decimal? valorPIS { get; set; }
        public decimal? valorCOFINS { get; set; }
        public decimal? valorDespesas { get; set; }
        public decimal? valorFrete { get; set; }
        public decimal? valorSeguro { get; set; }
        public decimal? valorDesconto { get; set; }
        public decimal? valorMercadoria { get; set; }
        public decimal? valorTotal { get; set; }
    }

}
