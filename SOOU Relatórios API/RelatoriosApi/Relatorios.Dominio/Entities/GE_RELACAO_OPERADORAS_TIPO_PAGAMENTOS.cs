﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_RELACAO_OPERADORAS_TIPO_PAGAMENTOS
    {
        public int COD_RELACAO { get; set; }
        public int COD_CARTAO { get; set; }
        public int COD_PAGAMENTO { get; set; }
        public int NUM_PARCELA { get; set; }
        public decimal? VLR_TAXA { get; set; }

        public virtual GE_OPERADORAS_CARTAO COD_CARTAONavigation { get; set; } = null!;
        public virtual GE_TIPO_PAGAMENTO COD_PAGAMENTONavigation { get; set; } = null!;
    }
}