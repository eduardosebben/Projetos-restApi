using System;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response
{
    public class ResponseBase
    {
        public Boolean TemErro { get; set; }
        public String Mensagem { get; set; }
    }
}
