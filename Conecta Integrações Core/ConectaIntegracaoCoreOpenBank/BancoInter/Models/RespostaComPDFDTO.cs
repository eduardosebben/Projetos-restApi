using ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response;
using System;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models
{
    public class RespostaComPDFDTO : ResponseBase
    {
        public string  pdf { get; set; }
        public byte[] hashPdf { get; set; }
        public DefaultTokenDTO tokenDTO { get; set; }
    }
}
