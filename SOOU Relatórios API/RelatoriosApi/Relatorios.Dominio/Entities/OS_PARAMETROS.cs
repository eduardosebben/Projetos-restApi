﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class OS_PARAMETROS
    {
        public int COD_PARAMETRO { get; set; }
        public bool? TIP_AUTO_NUMERACAO { get; set; }
        public int? NUM_ULTIMA_ORDEM { get; set; }
        public string? DES_OBSERVACAO_RODAPE { get; set; }
        public decimal? VLR_PADRAO_ORCAMENTO { get; set; }
        public int COD_EMPRESA { get; set; }
        public int? COD_STATUS_APROVACAO { get; set; }
        public int? COD_STATUS_REPROVACAO { get; set; }
        public int? COD_STATUS_FATURADO_PARCIAL { get; set; }
        public int? COD_STATUS_FATURADO_TOTAL { get; set; }
        public int? COD_STATUS_INICIAL { get; set; }
        public string? DES_TITULO_OBSERVACAO { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual OS_STATUS_ORDEM? COD_STATUS_APROVACAONavigation { get; set; }
        public virtual OS_STATUS_ORDEM? COD_STATUS_FATURADO_PARCIALNavigation { get; set; }
        public virtual OS_STATUS_ORDEM? COD_STATUS_FATURADO_TOTALNavigation { get; set; }
        public virtual OS_STATUS_ORDEM? COD_STATUS_INICIALNavigation { get; set; }
        public virtual OS_STATUS_ORDEM? COD_STATUS_REPROVACAONavigation { get; set; }
    }
}