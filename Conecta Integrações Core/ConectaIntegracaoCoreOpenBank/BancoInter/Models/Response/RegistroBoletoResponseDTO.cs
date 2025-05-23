﻿namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response
{
    public class RegistroBoletoResponseDTO : ResponseBase
    {
        public string seuNumero { get; set; }
        public string nossoNumero { get; set; }
        public string codigoBarras { get; set; }
        public string linhaDigitavel { get; set; }
        public DefaultTokenDTO tokenDTO { get; set; }

    }
}
