﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CA_PARAMETROS
    {
        public int COD_EMPRESA { get; set; }
        public bool TIP_UTILIZA_CAIXA { get; set; }
        public bool? TIP_UTILIZA_CAIXA_CEGO { get; set; }
        public bool TIP_PERMITE_FECHAR_INCONSISTENTE { get; set; }
        public decimal VLR_TOLERANCIA_FECHAMENTO { get; set; }
    }
}