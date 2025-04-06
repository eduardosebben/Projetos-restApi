﻿using ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models.ContaCorrente
{
    public class SaldoResponseDTO : ResponseBase
    {
        public decimal bloqueadoCheque { get; set; }
        public decimal disponivel { get; set; }
        public decimal bloqueadoJudicialmente { get; set; }
        public decimal bloqueadoAdministrativo { get; set; }
        public decimal limite { get; set; }
    }
}
