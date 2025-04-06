using Relatorios.Dominio.Entities.Entities;

namespace Relatorios.Aplication.Vendas.Models
{
    public record RelatorioNFeNFCeNotaResponse
    {
        public int codNota { get; set; }
        public int numNota { get; set; }
        public string desSerie { get; set; }
        public string desPessoa { get; set; }
        public DateTime? dataEmissao { get; set; }
        public DateTime? dataAutorizacao { get; set; }
        public string LabelStatusNFe { get; set; }
        public string NomeStatusNFe { get; set; }
        public decimal totalBaseICMS { get; set; }
        public decimal totalValorICMS { get; set; }
        public decimal totalBaseICMS_ST { get; set; }
        public decimal totalValorICMS_ST { get; set; }
        public decimal totalValorIPI { get; set; }
        public decimal totalValorPIS { get; set; }
        public decimal valorDespesa { get; set; }
        public decimal valorFrete { get; set; }
        public decimal valorSeguro { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal valorTotalProdutos { get; set; }
        public decimal valorTotalNota { get; set; }
        public int indSituacao { get; set; }
        public string desCondicaoPagamento { get; set; }
        public List<RelatorioNFeNFCeNotaProduto> produtos { get; set; }

        public RelatorioNFeNFCeNotaResponse()
        {

        }

        internal static List<RelatorioNFeNFCeNotaResponse> QueryToRelatorioNFeNFCeNotaResponse(IQueryable<FT_NOTAS> query)
        {
            var notas = query.Select(nota => new RelatorioNFeNFCeNotaResponse()
            {
                codNota = nota.COD_NOTA,
                numNota = nota.NUM_NOTA,
                desSerie = nota.DES_SERIE,
                dataAutorizacao = nota.DTA_AUTORIZACAO,
                dataEmissao = nota.DTA_EMISSAO,
                desPessoa = nota.DES_PESSOA,
                valorTotalNota = nota.VLR_TOTAL ?? 0,
                valorSeguro = nota.VLR_SEGURO ?? 0,
                valorDesconto = nota.VLR_DESCONTO ?? 0,
                valorDespesa = nota.VLR_DESPESA ?? 0,
                valorFrete = nota.VLR_FRETE ?? 0,
                totalBaseICMS = nota.VLR_BASE_ICMS ?? 0,
                totalBaseICMS_ST = nota.VLR_BASE_ST ?? 0,
                totalValorICMS = nota.VLR_ICMS ?? 0,
                totalValorICMS_ST = nota.VLR_ST ?? 0,
                totalValorIPI = nota.VLR_IPI ?? 0,
                totalValorPIS = nota.VLR_PIS ?? 0,
                valorTotalProdutos = nota.VLR_MERCADORIA ?? 0,
                desCondicaoPagamento = nota.COD_CONDICAO_PAGAMENTONavigation.DES_CONDICAO_PAGAMENTO,
                produtos = nota.FT_NOTAS_ITENS.Select(item => new RelatorioNFeNFCeNotaProduto()
                {
                    codItem = item.COD_ITEM,
                    numSequencia = item.NUM_SEQUENCIA,
                    codSKU = item.COD_PRODUTONavigation.COD_PRODUTO_EMPRESA, //sku
                    desProduto = item.DES_PRODUTO,
                    unidadeMedida = item.COD_UNIDADE_MEDIDANavigation.DES_SIGLA,
                    qtdProduto = item.QTD_PRODUTO,
                    desOperacaoFiscal = item.COD_OPERACAO_FISCALNavigation.DES_OPERACAO_FISCAL,
                    valorUnitario = item.VLR_UNITARIO,
                    valorBaseICMS = item.VLR_BASE_ICMS,
                    valorICMS = item.VLR_ICMS,
                    valorBaseST = item.VLR_BASE_ST,
                    valorST = item.VLR_ST,
                    valorSTRetido = item.VLR_ST_RETIDO,
                    valorIPI = item.VLR_IPI,
                    valorPIS = item.PER_PIS,
                    valorCOFINS = item.VLR_COFINS,
                    valorDespesas = item.VLR_DESPESAS,
                    valorFrete = item.VLR_FRETE,
                    valorDesconto = item.VLR_DESCONTO,
                    valorSeguro = item.VLR_SEGURO,
                    valorTotal = item.VLR_TOTAL,
                    valorMercadoria = item.VLR_MERCADORIA,
                }).ToList(),
                indSituacao = nota.IND_SITUACAO,
            }).ToList();

            return notas;
        }


    }

}
