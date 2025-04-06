using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.DRE.Models
{
    public class ConfiguradorRelatorioDREDto
    {
        public DadosAcessoModelDRE dadosAcessoModelDRE { get; set; }
        public DateTime? dtaMesAno { get; set; }
        public bool IndConferencia { get; set; }
        public bool IndRazaoContas { get; set; }
        public bool IndConsiderarCustoSemProducao { get; set; }
        public int? IndComissoes { get; set; }
        public int? codProduto { get; set; }
        public ConfiguradorRelatorioDREDto(){}
    }
    public record DadosAcessoModelDRE
    {
        public int CodigoOrganizacao { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoUsuario { get; set; }

        public DadosAcessoModelDRE()
        {

        }
    }
}
