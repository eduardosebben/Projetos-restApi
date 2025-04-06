using ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response;
using System.Collections.Generic;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models.ContaCorrente
{
    public class ExtratoResponseDTO : ResponseBase
    {
        public List<TransacoesExtratoDTO> transacoes { get; set; }
    }

    public class TransacoesExtratoDTO
    {
        public string dataEntrada { get; set; }
        public string tipoTransacao { get; set; }
        public string tipoOperacao { get; set; }
        public string valor { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string codigoHistorico { get; set; }

    }
}
