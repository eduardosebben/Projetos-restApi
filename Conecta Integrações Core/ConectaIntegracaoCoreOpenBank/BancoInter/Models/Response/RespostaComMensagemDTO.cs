using System;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response
{
    public class RespostaComMensagemDTO : ResponseBase
    {
        public String message { get; set; }
        public DefaultTokenDTO tokenDTO { get; set; }   
    }
}
