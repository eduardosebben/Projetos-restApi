﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_SEGURADORAS
    {
        public GE_SEGURADORAS()
        {
            FT_MDFE_SEGURO_CARGA = new HashSet<FT_MDFE_SEGURO_CARGA>();
        }

        public int COD_SEGURADORA { get; set; }
        public string? DES_SEGURADORA { get; set; }
        public string? NUM_CNPJ_SEGURADORA { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_ORGANIZACAO { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual ICollection<FT_MDFE_SEGURO_CARGA> FT_MDFE_SEGURO_CARGA { get; set; }
    }
}