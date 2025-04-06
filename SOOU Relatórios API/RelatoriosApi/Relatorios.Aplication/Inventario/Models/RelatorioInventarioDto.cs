using Relatorios.Dominio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Inventario.Models
{
    public class RelatorioInventarioDto
    {
        public DateTime? DtaReferencia { get; set; }
        public decimal QtdEstoqueTotal => Produtos.Sum(x => x.QuantidadeEstoque);
        public decimal VlrTotal => Produtos.Sum(x => x.VlrTotal);
        public IEnumerable<ProdutosModel> Produtos { get; set; } = new List<ProdutosModel>();

        public RelatorioInventarioDto()
        {

        }

        public RelatorioInventarioDto(ConfiguradorRelatorioInventarioDto model)
        {
            DtaReferencia = model.DtaReferencia;
        }

        public class ProdutosModel
        {
            public decimal QuantidadeEstoque { get; set; }
            public string Almoxarifado { get; set; }
            public decimal Valor { get; set; }
            public decimal VlrTotal => Valor * QuantidadeEstoque;

            public int? NumCasasDecimaisUnidadeMedida { get; set; }
            public string CodSku { get; set; }
            public int CodProduto { get; set; }
            public string DesProduto { get; set; }
            public string DesClassificacaoFiscal { get; set; }
            public string DesUnidadeMedida { get; set; }
            public int CodUnidadeMedida { get; set; }

            public ProdutosModel()
            {

            }
        }
    }

   


    public class RelatorioInventarioGeralDto
    {
        public DateTime? dtaReferencia { get; set; }
        public IEnumerable<RelatorioInventaioGeralProdutoDto> produtos { get; set; }
        public ConfiguradorRelatorioInventarioDto configuracoes { get; set; }
        public decimal vlrTotal { get; set; }
        public decimal qtdEstoqueTotal { get; set; }

        public RelatorioInventarioGeralDto()
        {

        }

        public RelatorioInventarioGeralDto(RelatorioInventarioDto relatorio, ConfiguradorRelatorioInventarioDto configuracao)
        {
            dtaReferencia = relatorio.DtaReferencia;
            produtos = relatorio.Produtos.Select(x => new RelatorioInventaioGeralProdutoDto(x));
            vlrTotal = relatorio.VlrTotal;
            qtdEstoqueTotal = relatorio.QtdEstoqueTotal;
            configuracoes = configuracao;
        }


    }

    public class RelatorioInventaioGeralProdutoDto
    {
        public string codSku { get; set; }
        public int codProduto { get; set; }
        public string desProduto { get; set; }
        public string desClassificacaoFiscal { get; set; }
        public string desAlmox { get; set; }
        public string desUnidadeMedida { get; set; }
        public int codUnidadeMedida { get; set; }
        public decimal quantidade { get; set; }
        public decimal valor { get; set; }
        public decimal vlrTotal { get; set; }

        public RelatorioInventaioGeralProdutoDto()
        {

        }

        public RelatorioInventaioGeralProdutoDto(RelatorioInventarioDto.ProdutosModel x)
        {
            codSku = x.CodSku;
            desProduto = x.DesProduto;
            desClassificacaoFiscal = x.DesClassificacaoFiscal;
            desAlmox = x.Almoxarifado;
            desUnidadeMedida = x.DesUnidadeMedida;
            valor = x.Valor;
            var numeroCasasDecimais = x.NumCasasDecimaisUnidadeMedida.HasValue
                ? x.NumCasasDecimaisUnidadeMedida.Value : 2;
            quantidade = x.QuantidadeEstoque;
            vlrTotal = x.VlrTotal;
            codProduto = x.CodProduto;
            codUnidadeMedida = x.CodUnidadeMedida;
        }
    }
}
