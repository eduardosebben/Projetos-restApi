using ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response;
using System;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models
{
    public class DefaultTokenDTO : ResponseBase
    {
        public String access_token { get; set; }
        public String refresh_token { get; set; }
        public String token_type { get; set; }
        public DateTime dataGeracao {get;set;}
    }
}
