using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.EmpresasPadrao.Models
{

    public class EmpresasPadraoCollection
    {
        public int CodEmpresa { get; }
        private List<EmpresaPadraoCollectionItem> _empresasPadrao = new List<EmpresaPadraoCollectionItem>();
        public List<EmpresaPadraoCollectionItem> TodasEmpresasPadroes => _empresasPadrao;

        /// <summary>
        /// use EmpresaPadraoCollectionItem[{tipo empresa}] retornar padrao
        /// </summary>
        /// <param name="empresaPadrao"></param>
        /// <returns></returns>
        public EmpresaPadraoCollectionItem this[EmpresaPadrao empresaPadrao] => BuscarPorStatus(empresaPadrao);

        public EmpresasPadraoCollection(GE_EMPRESAS_PADRAO e)
        {
            CodEmpresa = e.COD_EMPRESA;

            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Pessoas, e.COD_EMP_PESSOAS));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Mensagens, e.COD_EMP_MENSAGENS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.OperacaoFiscal, e.COD_EMP_OPERACAO_FISCAL ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Bancos, e.COD_EMP_BANCOS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.TipoPagamento, e.COD_EMP_TIPO_PAGAMENTO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.CondicaoPagamento, e.COD_EMP_CONDICAO_PAGAMENTO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.UnidadeMedida, e.COD_EMP_UNIDADE_MEDIDA ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ClassificacaoFiscal, e.COD_EMP_CLASSIFICACAO_FISCAL ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Produtos, e.COD_EMP_PRODUTOS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Logada, e.COD_EMPRESA));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.TipoTitulo, e.COD_EMP_TIPO_TITULO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ContaContabil, e.COD_EMP_CONTAS_CONTABEIS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Marcas, e.COD_EMP_MARCAS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.CategoriasProdutos, e.COD_EMP_CATEGORIAS_PRODUTOS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ClassificacaoProdutos, e.COD_EMP_CLASSIFICACOES_PRODUTOS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Almoxarifados, e.COD_EMP_ALMOXARIFADOS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.RegraTributacao, e.COD_EMP_REGRA_TRIBUTACAO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.Indices, e.COD_EMP_INDICE ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.CentroCusto, e.COD_EMP_CENTRO_CUSTO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.AlmoxarifadoProduto, e.COD_EMP_PRODUTO_ALMOXARIFADOS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ListaPreco, e.COD_EMP_LISTA_PRECO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ProdutosValores, e.COD_EMP_PRODUTOS_VALORES ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.OperadorasCartao, e.COD_EMP_OPERADORAS_CARTAO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ProdutoComposicao, e.COD_EMP_PRODUTO_COMPOSICAO ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ProgramaFidelidade, e.COD_EMP_PROGRAMA_FIDELIDADE ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.TipoPagamentoCondicaoPagamento, e.COD_EMP_TIPOS_PAGAMENTOS_CONDICOES_PAGAMENTOS ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.IBPT, e.COD_EMPRESA_IBPT ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.IFood, e.COD_EMPRESA_IFOOD ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.EmpresaPromocoes, e.COD_EMP_PROMOCOES ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.TiposOrdem, e.COD_EMP_TIPOS_ORDEM ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.StatusOrdem, e.COD_EMP_STATUS_ORDEM ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.TecnicosOrdem, e.COD_EMP_TECNICO_ORDEM ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.TipoMovimentoCaixa, e.COD_EMP_TIPO_MOVIMENTOS_CAIXA ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.ContaDRE, e.COD_EMP_PLANO_DRE ?? CodEmpresa));
            _empresasPadrao.Add(new EmpresaPadraoCollectionItem(EmpresaPadrao.CanalVenda, e.COD_EMP_CANAL_VENDAS ?? CodEmpresa));
        }

        public EmpresaPadraoCollectionItem RetornarEmpresaPadrao(EmpresaPadrao empresaPadrao) => BuscarPorStatus(empresaPadrao);

        private EmpresaPadraoCollectionItem BuscarPorStatus(EmpresaPadrao empresaPadrao)
        {
            var resultado = _empresasPadrao.FirstOrDefault(x => x.TipoEmpresa == empresaPadrao);
            if (resultado != null)
                return resultado;

            throw new ArgumentOutOfRangeException(
                nameof(empresaPadrao),
                $"Empresa padrão não prevista {empresaPadrao} não suportado");
        }
    }
}
