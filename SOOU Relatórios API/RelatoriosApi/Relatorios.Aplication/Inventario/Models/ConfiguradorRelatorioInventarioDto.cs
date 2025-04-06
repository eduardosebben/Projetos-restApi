using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Inventario.Models
{
    public class ConfiguradorRelatorioInventarioDto
    {
        public DadosAcessoModel DadosAcesso { get; set; }
        public FiltrosModel? Filtros { get; set; } = new FiltrosModel();
        public DateTime? DtaReferencia { get; set; }
        public DateTime? MesAnoReferencia { get; set; }
        public CampoValor IndCampoValor { get; set; }
        public bool TipProdutosDesativados { get; set; } = false;
        public bool TipListarComEstoqueNegativo { get; set; } = false;
        public bool TipListarApenasComQtdeEstoque { get; set; } = false;
        public int IndOrdem { get; set; }

        public ConfiguradorRelatorioInventarioDto()
        {

        }
    }

    public class FiltrosModel
    {
        public string? CodSku { get; set; } = string.Empty;
        public string? DesProduto { get; set; } = string.Empty;
        public List<int> ListaMarcas { get; set; } = new List<int>();
        public List<int> ListaCategorias { get; set; } = new List<int>();
        public List<int> ListaClassificacoesFiscais { get; set; } = new List<int>();
        public List<int> ListaAlmoxarifados { get; set; } = new List<int>();
    }


    public enum CampoValor
    {
        CustoMedio,
        CustoReal
    }

    public record DadosAcessoModel
    {
        public int CodigoOrganizacao { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoUsuario { get; set; }

        public DadosAcessoModel()
        {
            
        }
    }
}
