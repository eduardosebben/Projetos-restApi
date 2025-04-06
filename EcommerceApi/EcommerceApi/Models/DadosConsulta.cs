using EcommerceNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Models
{
    public class DadosConsulta
    {
        public string itemID { get; set; } = string.Empty;
        public string categoriaID { get; set; } = string.Empty;
        public string imagemID { get; set; } = string.Empty;
        public string usuarioID { get; set; } = string.Empty;
        public string marcaID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosConsultaTipoPublicacao
    {
        public string itemID { get; set; } = string.Empty;
        public string categoriaID { get; set; } = string.Empty;
        public string tipoLista { get; set; } = string.Empty;
        public string custoID { get; set; } = string.Empty;
        public string exposicaoID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosCategorizacaoProdutos
    {
        public string complementoProduto { get; set; } = string.Empty;
        public string categoriaID { get; set; } = string.Empty;
        public string dominioIDUm { get; set; } = string.Empty;
        public string dominioIDDois { get; set; } = string.Empty;
        public string itemID { get; set; } = string.Empty;
        public string compatibilidadeID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosPrecosCustos
    {
        public string canalVendas { get; set; } = string.Empty;
        public string nivelComprador { get; set; } = string.Empty;
        public string itemID { get; set; } = string.Empty;
        public decimal? preco { get; set; }
        public string tipoID { get; set; } = string.Empty;
        public string categoriaID { get; set; } = string.Empty;
        public string currencyID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosVariacao
    {
        public string categoriaID { get; set; } = string.Empty;
        public string itemID { get; set; } = string.Empty;
        public string variacaoID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosTabelaMedidas
    {
        public string itemID { get; set; } = string.Empty;
        public string dominioID { get; set; } = string.Empty;
        public string graficoID { get; set; } = string.Empty;
        public string vendedorID { get; set; } = string.Empty;
        public string categoriaID { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string local { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosCatalogo
    {
        public string statusID { get; set; } = string.Empty;
        public string siteID { get; set; } = string.Empty;
        public string produtoID { get; set; } = string.Empty;
        public string sugestaoID { get; set; } = string.Empty;
        public string usuarioID { get; set; } = string.Empty;
        public string itemID { get; set; } = string.Empty;
        public string[] itensID { get; set; }
        public string descricaoProduto { get; set; } = string.Empty;
        public string dominioID { get; set; } = string.Empty;
        public string descricaoFiltro { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosEstoqueFulfillment
    {
        public string categoriaID { get; set; } = string.Empty;
        public string inventarioID { get; set; } = string.Empty;
        public string vendedorID { get; set; } = string.Empty;
        public string dataInicial { get; set; } = string.Empty;
        public string dataFinal { get; set; } = string.Empty;
        public string operacaoID { get; set; } = string.Empty; 
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosPromocoes
    {
        public string usuarioID { get; set; } = string.Empty;
        public string canditadoID { get; set; } = string.Empty;
        public string ofertaID { get; set; } = string.Empty;
        public string promocaoID { get; set; } = string.Empty;
        public string tipoPromocao { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string itemID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosPerguntasRespostas
    {
        public string vendedorID { get; set; } = string.Empty;
        public string itemID { get; set; } = string.Empty;
        public string dataCriacao { get; set; } = string.Empty;
        public string custoID { get; set; } = string.Empty;
        public string questaoID { get; set; } = string.Empty;
        public string usuarioID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosGerencieVendas
    {
        public string ordemID { get; set; } = string.Empty;
        public string currencyIDIni { get; set; } = string.Empty;
        public string CurrencyIDFim { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string vendedorIni { get; set; } = string.Empty;
        public string vendedorFim { get; set; } = string.Empty;
        public string dataCriacaoIni { get; set; } = string.Empty;
        public string dataCriacaoFim { get; set; } = string.Empty;
        public string vendedorID { get; set; } = string.Empty;
        public string CompradorID { get; set; } = string.Empty;
        public string pacoteID { get; set; } = string.Empty;
        public string remessaID { get; set; } = string.Empty;
        public string feedbackID { get; set; } = string.Empty;
        public string custoID { get; set; } = string.Empty;
        public string scrollID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosFaturador
    {
        public string usuarioID { get; set; } = string.Empty;
        public int? codErro { get; set; } = null;
        public string regraID { get; set; } = string.Empty;
        public string mensagemID { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string itemID { get; set; } = string.Empty;
        public string variacaoID { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string invoiceID { get; set; } = string.Empty;
        public int? notaID { get; set; } = null;
        public string ordemID { get; set; } = string.Empty;
        public string remessaID { get; set; } = string.Empty;
        public string dataIni { get; set; } = string.Empty;
        public string dataFim { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosRelatorioFaturamento
    {
        public string dataPeriodo { get; set; } = string.Empty;
        public string grupo { get; set; } = string.Empty;
        public string fileID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosEnviarNotaFiscal
    {
        public string ordemID { get; set; } = string.Empty;
        public string remessaID { get; set; } = string.Empty;
        public string pacoteID { get; set; } = string.Empty;
        public string notaFiscalID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosMensagensPosVenda
    {
        public string pacoteID { get; set; } = string.Empty;
        public string usuarioID { get; set; } = string.Empty;
        public string mensagemID { get; set; } = string.Empty;
        public string anexoID { get; set; } = string.Empty;
        public string recurso { get; set; } = string.Empty;
        public string papel { get; set; } = string.Empty;
        public string vendedorID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class MetricasTendencias
    {
        public string itemID { get; set; } = string.Empty;
        public string catalogoProdutoID { get; set; } = string.Empty;
        public string usuarioID { get; set; } = string.Empty;
        public string categoriaID { get; set; } = string.Empty;
        public int? atributo { get; set; }
        public string produtoID { get; set; } = string.Empty;
        public string dataIni { get; set; } = string.Empty;
        public string dataFim { get; set; } = string.Empty;
        public string vendedorID { get; set; } = string.Empty;
        public bool? incluirItens  { get; set; } = false;
        public int? versao { get; set; }
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
    public class DadosReclamacoesDevolucoes
    {
        public string dataIni { get; set; } = string.Empty;
        public string dataFim { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string reclamacaoID { get; set; } = string.Empty;
        public string anexoID { get; set; } = string.Empty;
        public LogarDtoResponse logar { get; set; } = new LogarDtoResponse();
    }
}
