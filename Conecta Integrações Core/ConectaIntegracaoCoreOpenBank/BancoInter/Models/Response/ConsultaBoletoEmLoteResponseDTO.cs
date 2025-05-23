﻿using System;
using System.Collections.Generic;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response
{
    public class ConsultaBoletoEmLoteResponseDTO : ResponseBase
    {
        public Int32 totalPages { get; set; }
        public Int32 totalElements { get; set; }
        public Boolean last { get; set; }
        public Boolean first { get; set; }
        public Int32 size { get; set; }
        public Int32 numberOfElements { get; set; }
        public List<ConsultaBoletoIndividualResponseDTO> content { get; set; }
        public DefaultTokenDTO tokenDTO { get; set; }
    }
}
