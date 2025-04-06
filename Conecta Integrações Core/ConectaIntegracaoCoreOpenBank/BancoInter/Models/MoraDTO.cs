using System;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models
{
    public class MoraDTO
    {
        public String codigoMora { get; set; }
        public String data { get; set; }
        public Double taxa { get; set; }
        public Decimal valor { get; set; }
    }
}
