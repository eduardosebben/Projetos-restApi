using System;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models
{
    public class DescontoDTO
    {
        public String codigoDesconto { get; set; }
        public String data { get; set; }
        public Double taxa { get; set; }
        public Decimal valor { get; set; }
    }
}
