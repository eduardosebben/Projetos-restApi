using System;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models
{
    public class ConfiguracaoEmpresa
    {
        public String ClientId { get; set; }
        public String ClientSecret { get; set; }
        public String HashCertificado { get; set; }
        public String SenhaCertificado { get; set; }
        public string desToken {  get; set; }
    }
}
